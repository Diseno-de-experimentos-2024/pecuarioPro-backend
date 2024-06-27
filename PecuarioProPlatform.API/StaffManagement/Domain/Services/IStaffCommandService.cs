using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Services;

public interface IStaffCommandService
{
    Task<Staff?> Handle(CreateStaffCommand command);

    Task<Staff?> Handle(DeleteStaffCommand command);
}