using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

public class DepartmentRepository(AppDbContext context) : BaseRepository<Department>(context), IDepartmentRepository
{
    public async Task<Department?> FindDepartmentByNameAsync(string departmentName)
    {
        var department = await Context.Set<Department>().FirstOrDefaultAsync(d => d.Name == departmentName);
        return department;    }
}