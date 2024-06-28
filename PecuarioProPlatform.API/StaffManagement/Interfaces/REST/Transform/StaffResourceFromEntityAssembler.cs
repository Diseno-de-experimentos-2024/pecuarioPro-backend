using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Transform;

public static class StaffResourceFromEntityAssembler
{
    public static StaffResource ToResourceFromEntity(Staff entity)
    {
        return new StaffResource(entity.Id, entity.CampaignId, entity.FirstName, entity.LastName,entity.JobDescription, 
            entity.Email, entity.Status, entity.DateStart, entity.DateEnd);
    }
    
}