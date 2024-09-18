using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public static class VaccineResourceFromEntityAssembler
{
    public static VaccineResource ToResourceFromEntity(Vaccine entity)
    {
        
        return new VaccineResource(
            entity.Id,
            entity.Name,
            entity.Date,
            entity.Code,
            entity.Reason,
            entity.Dose,
            entity.UserId.Identifier,
            entity.BovineId.Identifier);
    }
}