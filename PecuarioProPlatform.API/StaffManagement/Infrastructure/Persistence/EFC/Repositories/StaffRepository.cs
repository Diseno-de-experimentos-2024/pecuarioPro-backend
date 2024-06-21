using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.StaffManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PecuarioProPlatform.API.StaffManagement.Infrastructure.Persistence.EFC.Repositories;

public class StaffRepository(AppDbContext context) : BaseRepository<Staff>(context), IStaffRepository
{
    public Task<Staff?> FindStaffByEmailAsync(EmailAddress email)
    {
        return Context.Set<Staff>().Where(s => s.Email == email).FirstOrDefaultAsync();
    }
    
}