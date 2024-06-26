using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.StaffManagement.Domain.Repositories;
using PecuarioProPlatform.API.StaffManagement.Domain.Services;

namespace PecuarioProPlatform.API.StaffManagement.Application.Internal.CommandServices;

public class StaffCommandService(IStaffRepository staffRepository, IUnitOfWork unitOfWork) : IStaffCommandService
{
    public async Task<Staff?> Handle(CreateStaffCommand command)
    {
        var staff = new Staff(command);
        try
        {
            await staffRepository.AddAsync(staff);
            await unitOfWork.CompleteAsync();
            return staff;
        } catch (Exception e)
        {
          Console.WriteLine($"Error creating staff: {e.Message}");
          return null;
        }
    }
}