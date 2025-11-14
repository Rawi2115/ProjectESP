public class AttractionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ArDescription { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public static AttractionDto FromEntity(Attractions attraction)
    {
        return new AttractionDto
        {
            Id = attraction.Id,
            Name = attraction.Name,
            ArName = attraction.ArName,
            Description = attraction.Description,
            ArDescription = attraction.ArDescription,
            Location = attraction.Location,
            ImageUrl = attraction.ImageUrl
        };
    }
    public static List<AttractionDto> FromEntities(List<Attractions> attractions)
    {
        return attractions.Select(a => FromEntity(a)).ToList();
    }
}