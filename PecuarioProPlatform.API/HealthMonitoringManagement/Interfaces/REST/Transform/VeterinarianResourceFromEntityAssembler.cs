using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform.Transform;

public class VeterinarianResourceFromEntityAssembler
{
    public static VeterinarianResource ToResourceFromEntity(Veterinarian entity)
    {
        return new VeterinarianResource(entity.Id, entity.FirstName, entity.LastName,entity.Specialty, 
            entity.PhoneNumber, entity.Email,entity.City, entity.Status, entity.PhotoUrl);
    }
}