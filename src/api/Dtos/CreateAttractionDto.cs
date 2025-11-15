public class CreateAttractionDto
{
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ArDescription { get; set; } = null!;
    public string? Location { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int ProvinceId { get; set; }
    
}