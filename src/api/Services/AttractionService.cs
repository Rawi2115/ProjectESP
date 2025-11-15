using Microsoft.EntityFrameworkCore;

public interface IAttractionService
{
    Task<List<AttractionDto>> GetAllAttractionsAsync(CancellationToken ct);
    Task<bool> CreateAttractionAsync(CreateAttractionDto dto,CancellationToken ct);
    Task<bool> EditAttractionAsync(int id, EditAttractionDto dto,CancellationToken ct);
    Task<bool> DeleteAttractionAsync(int id,CancellationToken ct);
}

public class AttractionService(SqliteDbContext sqliteDbContext):IAttractionService
{
    public async Task<List<AttractionDto>> GetAllAttractionsAsync(CancellationToken ct)
    {
        var attractions = await sqliteDbContext.Attractions.ToListAsync(ct);
        return AttractionDto.FromEntities(attractions);
    }

    public async Task<bool> CreateAttractionAsync(CreateAttractionDto dto,CancellationToken ct)
    {
        var attraction = new Attractions
        {
            Name = dto.Name,
            ArName = dto.ArName,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            ProvinceId = dto.ProvinceId
        };
        await sqliteDbContext.Attractions.AddAsync(attraction,ct);
        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
    public async Task<bool> EditAttractionAsync(int id, EditAttractionDto dto,CancellationToken ct)
    {
        var attraction = await sqliteDbContext.Attractions.FirstOrDefaultAsync(a => a.Id == id,ct);
        if (attraction == null) return false;

        attraction.Name = dto.Name;
        attraction.ArName = dto.ArName;
        attraction.Description = dto.Description;
        attraction.ArDescription = dto.ArDescription;
        attraction.Location = dto.Location;
        attraction.ImageUrl = dto.ImageUrl;

        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
    public async Task<bool> DeleteAttractionAsync(int id,CancellationToken ct)
    {
        var attraction = await sqliteDbContext.Attractions.FirstOrDefaultAsync(a => a.Id == id,ct);
        if (attraction == null) return false;

        sqliteDbContext.Attractions.Remove(attraction);
        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
}