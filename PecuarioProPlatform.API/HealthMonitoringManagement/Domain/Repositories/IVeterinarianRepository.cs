using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;

public interface IVeterinarianRepository : IBaseRepository<Veterinarian>
{
    
    Task<Veterinarian?> FindBySpecialty(string specialty);
    new Task<Veterinarian?> FindByIdAsync(int id);
}