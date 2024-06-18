using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform.Transform;

public class VeterinarianResourceFromEntityAssembler
{
    public static VeterinarianResource ToResourceFromEntity(Veterinarians entity)
    {
        return new VeterinarianResource(entity.Id, entity.FirstName, entity.LastName, entity.VetPermit,
            entity.ContactNumber, entity.Status, entity.Specialty);
    }
}