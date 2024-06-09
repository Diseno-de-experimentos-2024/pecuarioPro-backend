using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;

namespace PecuarioProPlatform.API.Shared.Domain.Services;

public interface ICityQueryService
{
    Task<City?> Handle(GetCityByIdQuery query);
}