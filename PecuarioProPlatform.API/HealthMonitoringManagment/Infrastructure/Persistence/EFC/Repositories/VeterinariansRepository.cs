using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Infrastructure.Persistence.EFC.Repositories;

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
}