using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Infrastructure.Persistence.EFC.Repositories;

public class VeterinariansRepository(AppDbContext context): BaseRepository<Veterinarian>(context), IVeterinarianRepository
{
    public Task<Veterinarian?> FindBySpecialty(string specialty)
    {
        return Context.Set<Veterinarian>().Where(p=>p.Specialty == specialty).FirstOrDefaultAsync();
    }

    public new Task<Veterinarian?> FindByIdAsync(int id)
    {
        return Context.Set<Veterinarian>().Where(p=>p.Id == id).FirstOrDefaultAsync();
    }
}