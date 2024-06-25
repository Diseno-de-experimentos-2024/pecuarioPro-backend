using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.QueryServices;

public class CityQueryService(ICityRepository cityRepository) : ICityQueryService
{
    private ICityQueryService _cityQueryServiceImplementation;
    public async Task<City?> Handle(GetCityByIdQuery query)
    {
        return await cityRepository.FindByIdAsync(query.CityId);
    }

    public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery query)
    {
        return await cityRepository.ListAsync();
    }

    public async Task<City?> Handle(GetCityByNameQuery query)
    {
        return await cityRepository.FindCityByNameAsync(query.cityName);
    }
}