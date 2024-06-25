using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;

namespace PecuarioProPlatform.API.Shared.Domain.Services;

public interface IDepartmentQueryService
{
    Task<Department?> Handle(GetDepartmentByIdQuery query);
    Task<IEnumerable<Department>> Handle(GetAllDepartmentsQuery query);
    Task<Department?> Handle(GetDepartmentByNameQuery query);
}