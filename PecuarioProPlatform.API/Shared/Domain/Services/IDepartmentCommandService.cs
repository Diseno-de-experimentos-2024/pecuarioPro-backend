using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.Shared.Domain.Services;

public interface IDepartmentCommandService
{
    Task<Department?> Handle(CreateDepartmentCommand command);
}