using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class UpdateVaccineCommandFromResourceAssembler
{
    public static UpdateVaccineCommand ToCommandFromResource(int vaccineId, CreateVaccineResource resource)
    {
       

        return new UpdateVaccineCommand(vaccineId, resource.Name, resource.Date, resource.Code, resource.Reason,resource.Dose);
    }
}