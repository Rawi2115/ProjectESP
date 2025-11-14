using Microsoft.EntityFrameworkCore;

public interface IProvinceService
{
    Task<ProvinceDto?> GetProvinceByIdAsync(int id,CancellationToken ct);
    Task<List<ProvinceDto>> GetAllProvincesAsync(CancellationToken ct);
    Task<bool> EditProvinceAsync(int id, EditProvinceRequest request,CancellationToken ct);
    
}

public class ProvinceService(SqliteDbContext sqliteDbContext):IProvinceService
{
    public async  Task<ProvinceDto?> GetProvinceByIdAsync(int id,CancellationToken ct)
    {
        var province = await sqliteDbContext.Provinces
            .Include(p => p.Attractions)
            .Include(p => p.Cities)
            .FirstOrDefaultAsync(p => p.Id == id,ct);
        if (province == null) return null;
        return ProvinceDto.FromEntity(province);
    }
    public async Task<List<ProvinceDto>> GetAllProvincesAsync(CancellationToken ct)
    {
        var provinces = await sqliteDbContext.Provinces
            .Include(p => p.Attractions)
            .Include(p => p.Cities)
            .ToListAsync(ct);
        return provinces.Select(ProvinceDto.FromEntity).ToList();
    }
    public async Task<bool> EditProvinceAsync(int id, EditProvinceRequest request,CancellationToken ct)
    {
        var province = await sqliteDbContext.Provinces
            .Include(p => p.Cities)
            .FirstOrDefaultAsync(p => p.Id == id,ct);
        if (province == null) return false;

        province.Name = request.Name;
        province.ArName = request.ArName;
        province.Description = request.Description;
        province.ImageUrl = request.ImageUrl;
        province.Population = request.Population;
        province.Area = request.Area;

        // Update cities
        foreach(var city in request.Cities)
        {
            var existingCity =  province.Cities.FirstOrDefault(c => c.Id == city.Id);
            if (existingCity != null)
            {
                existingCity.Name = city.Name;
                existingCity.ArName = city.ArName;
            }
            else
            {
                province.Cities.Add(new City
                {
                    Name = city.Name,
                    ArName = city.ArName,
                    ProvinceId = province.Id
                });
            }
        }
        foreach(var attraction in request.Attractions)
        {
            var existingAttraction = province.Attractions.FirstOrDefault(a => a.Id == attraction.Id);
            if (existingAttraction != null)
            {
                existingAttraction.Name = attraction.Name;
                existingAttraction.ArName = attraction.ArName;
                existingAttraction.Description = attraction.Description;
                existingAttraction.ImageUrl = attraction.ImageUrl;
            }
            else
            {
                province.Attractions.Add(new Attractions
                {
                    Name = attraction.Name,
                    ArName = attraction.ArName,
                    Description = attraction.Description,
                    ImageUrl = attraction.ImageUrl,
                    ProvinceId = province.Id
                });
            }
        }
        await sqliteDbContext.SaveChangesAsync();
        return true;
    }
}