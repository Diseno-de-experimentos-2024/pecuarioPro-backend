using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IBovineCommandService
{
    Task<Bovine?> Handle(CreateBovineCommand command);
    int Handle(AddImageAssetToBovineCommand command);
    int Handle(ModifyWeightBovineCommand command);
}