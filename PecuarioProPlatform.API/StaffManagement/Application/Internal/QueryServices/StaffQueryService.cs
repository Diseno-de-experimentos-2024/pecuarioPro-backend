using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.StaffManagement.Domain.Repositories;
using PecuarioProPlatform.API.StaffManagement.Domain.Services;

namespace PecuarioProPlatform.API.StaffManagement.Application.Internal.QueryServices;

public class StaffQueryService(IStaffRepository staffRepository) : IStaffQueryService
{
    public async Task<IEnumerable<Staff>> Handle(GetAllStaffsQuery query)
    {
        return await staffRepository.ListAsync();
    }

    public async Task<Staff?> Handle(GetStaffByEmailQuery query)
    {
        return await staffRepository.FindStaffByEmailAsync(query.Email);
    }

    public async Task<Staff?> Handle(GetStaffByIdQuery query)
    {
        return await staffRepository.FindByIdAsync(query.StaffId);
    }

}