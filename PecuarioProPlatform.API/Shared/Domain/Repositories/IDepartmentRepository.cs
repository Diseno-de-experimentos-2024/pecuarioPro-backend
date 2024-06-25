using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.Shared.Domain.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<Department?> FindDepartmentByNameAsync(String departmentName);

}