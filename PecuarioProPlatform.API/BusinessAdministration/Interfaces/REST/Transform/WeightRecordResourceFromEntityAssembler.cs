using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class WeightRecordResourceFromEntityAssembler
{
    public static WeightRecordResource ToResourceFromEntity(WeightRecord entity)
    {
        return new WeightRecordResource(entity.Id, entity.BovineId, entity.Weight, entity.RecordDate);
    }
}