

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("cards")]
public class CardsController(IHubContext<RfidHub> hub,SqliteDbContext sqliteDbContext) : Controller
{

    [HttpPost]
    public async Task<IActionResult> ScanCard([FromBody] CardData cardData, CancellationToken ct)
    {
        var existingCard = await sqliteDbContext.Cards.Include(c => c.Province).FirstOrDefaultAsync(c => c.Uid == cardData.Uid, ct);
        if (existingCard == null)
        {
            var newCard = new Card { Uid = cardData.Uid };
            await hub.Clients.Group("Dashboard").SendAsync("ReceiveUid", cardData.Uid, ct);
            await sqliteDbContext.Cards.AddAsync(newCard, ct);
            await sqliteDbContext.SaveChangesAsync(ct);

        }else if (existingCard.ProvinceId == null)
        {
            await hub.Clients.All.SendAsync("UnAssignedCard", cardData.Uid, ct);
        }
        else
        {
            var cardDto = CardDto.FromEntity(existingCard, existingCard.Province);
            await hub.Clients.Group("Client").SendAsync("ReceiveCard", cardDto, ct);
        }
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetCards(CancellationToken ct)
    {
        var cards = await sqliteDbContext.Cards.Include(c => c.Province).ToListAsync(ct);
        var cardDtos = cards.Select(c => CardDto.FromEntity(c, c.Province)).ToList();
        return Ok(cardDtos);
    }
    [HttpPost("assign-province")]
    public async Task<IActionResult> AssignProvinceToCard([FromBody] AssignProvinceRequest request, CancellationToken ct)
    {
        var card = await sqliteDbContext.Cards.FirstOrDefaultAsync(c => c.Uid == request.Uid, ct);
        if (card == null)
        {
            return NotFound("Card not found");
        }
        card.ProvinceId = request.ProvinceId;
        await sqliteDbContext.SaveChangesAsync(ct);
        return Ok();
    }

}