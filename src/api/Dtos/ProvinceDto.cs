public class ProvinceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public List<CityDto> Cities { get; set; } = new List<CityDto>();
    public int Population { get; set; }
    public double Area { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public List<AttractionDto> Attractions { get; set; } = new List<AttractionDto>();
    public static ProvinceDto FromEntity(Province province)
    {
        return new ProvinceDto
        {
            Id = province.Id,
            Name = province.Name,
            ArName = province.ArName,
            Population = province.Population,
            Area = province.Area,
            Description = province.Description,
            ImageUrl = province.ImageUrl,
            Cities = CityDto.FromEntities(province.Cities.ToList()),
            Attractions = AttractionDto.FromEntities(province.Attractions.ToList())
        };
    }
    public static List<ProvinceDto> FromEntities(List<Province> provinces)
    {
        return provinces.Select(p => FromEntity(p)).ToList();
    }
}
