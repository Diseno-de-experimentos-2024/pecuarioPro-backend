using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.StaffManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PecuarioProPlatform.API.StaffManagement.Infrastructure.Persistence.EFC.Repositories;

public class StaffRepository(AppDbContext context) : BaseRepository<Staff>(context), IStaffRepository
{
    public Task<Staff?> FindStaffByEmailAsync(string email)
    {
        return Context.Set<Staff>().Where(p=>p.Email == email).FirstOrDefaultAsync();
    }

    public new Task<Staff?> FindByIdAsync(int id)
    {
        return Context.Set<Staff>().Where(p=>p.Id == id).FirstOrDefaultAsync();
    }
    
}