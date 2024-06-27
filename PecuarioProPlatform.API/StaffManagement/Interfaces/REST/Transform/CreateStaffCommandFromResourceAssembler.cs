using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Transform;

public static class CreateStaffCommandFromResourceAssembler
{
    public static CreateStaffCommand ToCommandFromResource(CreateStaffResource resource)
    {
        return new CreateStaffCommand(resource.FirstName, resource.LastName,resource.JobDescription, resource.PhoneNumber, 
            resource.Email, resource.City, resource.Status ,resource.PhotoUrl);
    }

}