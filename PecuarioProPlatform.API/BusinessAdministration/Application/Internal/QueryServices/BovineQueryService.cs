using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;

public class BovineQueryService(IBovineRepository bovineRepository):IBovineQueryService
{
    private IBovineQueryService _bovineQueryServiceImplementation;

    public async Task<IEnumerable<Bovine>> Handle(GetAllBovinesByUserIdQuery query)
    {

        return await bovineRepository.FindByUserIdAsync(query.UserId);

    }

    public async Task<IEnumerable<Bovine>> Handle(GetAllBovinesByBatchIdQuery query)
    {
        return await bovineRepository.FindByBatchIdAsync(query.batchId);
    }

    public async Task<IEnumerable<Bovine>> Handle(GetAllBovinesByCampaignIdQuery query)
    {
        return await bovineRepository.FindByCampaignIdAsync(query.campaignId);
    }
    

    public  async Task<Bovine?> Handle(GetBovineByBovineIdentifierQuery query)
    {
        return await bovineRepository.FindByBovineIdentifierAsync(query.BovineIdentifier);
    }

    public async Task<Bovine?> Handle(GetBovineByIdQuery query)
    {
        return await bovineRepository.FindByIdAsync(query.bovineId);
    }

    public async Task<IEnumerable<Bovine>> Handle(GetAllBovinesByRaceIdQuery query)
    {
        return await bovineRepository.FindByRaceIdAsync(query.raceId);
    }

    public async Task<IEnumerable<WeightRecord>> Handle(GetAllWeightRecordsByBovineIdQuery query)
    {
        return await bovineRepository.FindByBovineIdAsync(query.bovineId);
    }
}