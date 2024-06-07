using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.QueryServices;

public class DepartmentQueryService(IDepartmentRepository departmentRepository ) :IDepartmentQueryService
{
    private IDepartmentQueryService _departmentQueryServiceImplementation;
    public async  Task<Department?> Handle(GetDepartmentByIdQuery query)
    {
        return await departmentRepository.FindByIdAsync(query.DepartmentId);
    }
}