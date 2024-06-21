using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Transform;

public static class StaffResourceFromEntityAssembler
{
    public static StaffResource ToResourceFromEntity(Staff entity)
    {
        return new StaffResource(entity.Id, entity.FullName, entity.EmailAddress, entity.StreetAddress);
    }
    
}