using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.QueryServices;

public class DistrictQueryService(IDistrictRepository districtRepository) : IDistrictQueryService
{
    private IDistrictQueryService _districtQueryServiceImplementation;
    public async Task<District?> Handle(GetDistrictByIdQuery query)
    {
        return await districtRepository.FindByIdAsync(query.DistrictId);
    }

    public async Task<IEnumerable<District>> Handle(GetAllDistrictsQuery query)
    {
        return await districtRepository.ListAsync();
    }

    public async Task<District?> Handle(GetDistrictByNameQuery query)
    {
        return await districtRepository.FindDistrictByNameAsync(query.districtName);
    }
}