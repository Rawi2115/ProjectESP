using Microsoft.EntityFrameworkCore;

public interface ICityService
{
    Task<List<CityDto>> GetAllCitiesAsync(CancellationToken ct);
    Task<bool> CreateCityAsync(CreateCityDto dto,CancellationToken ct);
    Task<bool> EditCityAsync(int id, EditCityDto dto,CancellationToken ct);
    Task<bool> DeleteCityAsync(int id,CancellationToken ct);
}

public class CityService(SqliteDbContext sqliteDbContext):ICityService
{
    public async Task<List<CityDto>> GetAllCitiesAsync(CancellationToken ct)
    {
        var cities = await sqliteDbContext.Cities.ToListAsync(ct);
        return CityDto.FromEntities(cities);
    }

    public async Task<bool> CreateCityAsync(CreateCityDto dto,CancellationToken ct)
    {
        var city = new City
        {
            Name = dto.Name,
            ArName = dto.ArName,
            ProvinceId = dto.ProvinceId
        };
        await sqliteDbContext.Cities.AddAsync(city,ct);
        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
    public async Task<bool> EditCityAsync(int id, EditCityDto dto,CancellationToken ct)
    {
        var city = await sqliteDbContext.Cities.FirstOrDefaultAsync(c => c.Id == id,ct);
        if (city == null) return false;

        city.Name = dto.Name;
        city.ArName = dto.ArName;
        city.ProvinceId = dto.ProvinceId;

        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
    public async Task<bool> DeleteCityAsync(int id,CancellationToken ct)
    {
        var city = await sqliteDbContext.Cities.FirstOrDefaultAsync(c => c.Id == id,ct);
        if (city == null) return false;

        sqliteDbContext.Cities.Remove(city);
        await sqliteDbContext.SaveChangesAsync(ct);
        return true;
    }
}