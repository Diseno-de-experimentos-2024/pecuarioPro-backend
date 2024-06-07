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
}