using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public static class VaccineResourceFromEntityAssembler
{
    public static VaccineResource ToResourceFromEntity(Vaccines entity)
    {
        return new VaccineResource(entity.Id, entity.Name, entity.Reason, entity.Code, entity.Description);
    }
}