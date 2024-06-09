using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class CreateVaccinesCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource)
    {
        return new CreateVaccineCommand(resource.Id,resource.Name, resource.Reason, resource.Code, resource.Description);
    }
}