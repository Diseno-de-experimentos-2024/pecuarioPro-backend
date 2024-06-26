using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Repositories;

public interface IStaffRepository : IBaseRepository<Staff>
{
    Task<Staff?> FindStaffByEmailAsync(EmailAddress email);
}