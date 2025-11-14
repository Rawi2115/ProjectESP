public class EditProvinceRequest
{
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public List<CityDto> Cities { get; set; } = new List<CityDto>();
    public List<AttractionDto> Attractions { get; set; } = new List<AttractionDto>();
    public int Population { get; set; }
    public double Area { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}