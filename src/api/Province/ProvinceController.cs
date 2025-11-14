

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("province")]
public class ProvinceController(IProvinceService provinceService):Controller
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProvinceById(int id,CancellationToken ct)
    {
        var province =  await provinceService.GetProvinceByIdAsync(id, ct);
        if (province == null) return NotFound();
        return Ok(province);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllProvinces(CancellationToken ct)
    {
        var provinces = await provinceService.GetAllProvincesAsync(ct);
        return Ok(provinces);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> EditProvince(int id, [FromBody] EditProvinceRequest request,CancellationToken ct)
    {
        var success = await provinceService.EditProvinceAsync(id, request, ct);
        if (!success) return NotFound();
        return Ok();
    }
}