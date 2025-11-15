using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("attraction")]
public class AttractionController(IAttractionService attractionService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllAttractions(CancellationToken ct)
    {
        var attractions = await attractionService.GetAllAttractionsAsync(ct);
        return Ok(attractions);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAttraction([FromBody] CreateAttractionDto dto, CancellationToken ct)
    {
        var success = await attractionService.CreateAttractionAsync(dto, ct);
        if (!success) return BadRequest();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAttraction(int id, [FromBody] EditAttractionDto dto, CancellationToken ct)
    {
        var success = await attractionService.EditAttractionAsync(id, dto, ct);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttraction(int id, CancellationToken ct)
    {
        var success = await attractionService.DeleteAttractionAsync(id, ct);
        if (!success) return NotFound();
        return Ok();
    }
}