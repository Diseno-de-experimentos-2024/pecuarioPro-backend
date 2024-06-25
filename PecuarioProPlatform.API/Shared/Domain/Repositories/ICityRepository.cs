using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.Shared.Domain.Repositories;

public interface ICityRepository : IBaseRepository<City>
{
    Task<City?> FindCityByNameAsync(String cityName);
    
}