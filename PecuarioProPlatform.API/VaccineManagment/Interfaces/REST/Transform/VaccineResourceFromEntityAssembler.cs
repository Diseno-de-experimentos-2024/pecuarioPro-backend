using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public static class VaccineResourceFromEntityAssembler
{
    public static VaccineResource ToResourceFromEntity(Vaccine entity)
    {
        // Convert VaccineDate and VaccineCode to string
        string date = entity.Date.ToString();
        string code = entity.Code.ToString();

        return new VaccineResource(
            entity.Id,
            entity.Name,
            date,
            code,
            entity.Reason);
    }
}