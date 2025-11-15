using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/images")]
public class ImagesController(IWebHostEnvironment env) : Controller
{
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        if(file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
            return BadRequest("Unsupported file type.");
        }
        var fileName = $"{Guid.NewGuid()}{extension}";
        var uploadPath = Path.Combine(env.WebRootPath,"uploads",fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(uploadPath)!);
        using (var stream = new FileStream(uploadPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { FileName = $"uploads/{fileName}" });
    }
}