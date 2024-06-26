using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Infrastructure.Persistence.EFC.Repositories;

public class VeterinariansRepository(AppDbContext context): BaseRepository<Veterinarians>(context), IVeterinarianRepository
{
    public Task<Veterinarians?> FindBySpecialty(string specialty)
    {
        return Context.Set<Veterinarians>().Where(p=>p.Specialty == specialty).FirstOrDefaultAsync();
    }

    public new Task<Veterinarians?> FindByIdAsync(int id)
    {
        return Context.Set<Veterinarians>().Where(p=>p.Id == id).FirstOrDefaultAsync();
    }

    public Task<Veterinarians?> FindByEmail(int email)
    {
        return Context.Set<Veterinarians>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}