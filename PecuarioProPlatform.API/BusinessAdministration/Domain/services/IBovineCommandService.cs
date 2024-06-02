using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IBovineCommandService
{
    Task<Bovine?> Handle(CreateBovineCommand command);
    Task<Bovine?> Handle(AddImageAssetToBovineCommand command);
    Task<Bovine?> Handle(ModifyWeightBovineCommand command);

    Task<Bovine> Handle(AddBovineToBatchCommand command);
    
    Task<Bovine> Handle(DeleteBovineToBatchCommand command);
}