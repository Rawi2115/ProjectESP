public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;

    public static CityDto FromEntity(City city)
    {
        return new CityDto
        {
            Id = city.Id,
            Name = city.Name,
            ArName = city.ArName
        };
    }
    public static List<CityDto> FromEntities(List<City> cities)
    {
        return cities.Select(c => FromEntity(c)).ToList();
    }
}
