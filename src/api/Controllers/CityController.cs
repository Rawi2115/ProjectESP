using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("city")]
public class CityController(ICityService cityService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllCities(CancellationToken ct)
    {
        var cities = await cityService.GetAllCitiesAsync(ct);
        return Ok(cities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityDto dto, CancellationToken ct)
    {
        var success = await cityService.CreateCityAsync(dto, ct);
        if (!success) return BadRequest();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCity(int id, [FromBody] EditCityDto dto, CancellationToken ct)
    {
        var success = await cityService.EditCityAsync(id, dto, ct);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id, CancellationToken ct)
    {
        var success = await cityService.DeleteCityAsync(id, ct);
        if (!success) return NotFound();
        return Ok();
    }
}