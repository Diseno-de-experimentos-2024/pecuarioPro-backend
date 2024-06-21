using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform.Transform;

public class CreateVeterinarianCommandFromResourceAssembler
{
    public static CreateVeterinarianCommand ToCommandFromResource(CreateVeterinarianResource resource)
    {
        return new CreateVeterinarianCommand(resource.Id, resource.FirstName, resource.LastName,resource.Specialty, resource.PhoneNumber, resource.Email, resource.PhotoUrl);
    }
}