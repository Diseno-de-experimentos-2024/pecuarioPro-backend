using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IRaceQueryService
{
    Task<Race?> Handle(GetRaceByIdQuery query);
}