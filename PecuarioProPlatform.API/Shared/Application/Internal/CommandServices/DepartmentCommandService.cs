using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.CommandServices;

public class DepartmentCommandService(IDepartmentRepository departmentRepository,IUnitOfWork unitOfWork) : IDepartmentCommandService
{
    private IDepartmentCommandService _departmentCommandServiceImplementation;
    public async Task<Department?> Handle(CreateDepartmentCommand command)
    {
        var department = new Department(command.name);
        try
        {
            departmentRepository.AddAsync(department);
            unitOfWork.CompleteAsync();
            return department;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a department:{e.Message} ");
            return null;
        }
    }
}