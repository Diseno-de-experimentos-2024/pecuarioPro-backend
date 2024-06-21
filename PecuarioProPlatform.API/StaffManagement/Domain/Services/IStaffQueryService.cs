using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Queries;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Services;

public interface IStaffQueryService
{
    Task<IEnumerable<Staff>> Handle(GetAllStaffsQuery query);
    
    Task<Staff?> Handle(GetStaffByEmailQuery query);
    
    Task<Staff?> Handle(GetStaffByIdQuery query);
}