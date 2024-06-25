using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

public class CityRepository(AppDbContext context) : BaseRepository<City>(context), ICityRepository
{
    public async Task<City?> FindCityByNameAsync(string cityName)
    {
        var city = await Context.Set<City>().FirstOrDefaultAsync(c => c.Name == cityName);
        return city;
    }
}