using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;

namespace PecuarioProPlatform.API.Shared.Domain.Services;

public interface IDistrictQueryService
{
    Task<District?> Handle(GetDistrictByIdQuery query);
    Task<IEnumerable<District>> Handle(GetAllDistrictsQuery query);
    Task<District?> Handle(GetDistrictByNameQuery query);
}