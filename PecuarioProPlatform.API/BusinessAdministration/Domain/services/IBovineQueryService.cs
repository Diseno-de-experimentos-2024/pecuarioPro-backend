using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IBovineQueryService
{
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesByUserIdQuery query);
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesByBatchIdQuery query);
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesByCampaignIdQuery query);
    Task<Bovine?> Handle(GetBovineByBovineIdentifierQuery query);
    Task<Bovine?> Handle(GetBovineByIdQuery query);
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesQuery query);
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesByRaceIdQuery query);

    Task<IEnumerable<WeightRecord>> Handle(GetAllWeightRecordsByBovineIdQuery query);
}