using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class DeleteVaccineCommandFromResourceAssembler
{
    public static DeleteVaccineCommand ToCommandFromResource(DeleteVaccineResource resource)
    {
        return new DeleteVaccineCommand(resource.Id);
    }
}