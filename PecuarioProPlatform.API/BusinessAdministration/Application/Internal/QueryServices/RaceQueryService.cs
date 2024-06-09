using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;

public class RaceQueryService(IRaceRepository raceRepository): IRaceQueryService
{
    private IRaceQueryService _raceQueryServiceImplementation;
    public async Task<Race?> Handle(GetRaceByIdQuery query)
    {
        return await raceRepository.FindByIdAsync(query.raceId);

    }
}