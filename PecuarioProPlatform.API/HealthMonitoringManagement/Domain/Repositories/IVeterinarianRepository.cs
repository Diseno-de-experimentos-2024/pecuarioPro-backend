using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;

public interface IVeterinarianRepository : IBaseRepository<Veterinarians>
{
    
    Task<Veterinarians?> FindBySpecialty(string specialty);
    new Task<Veterinarians?> FindByIdAsync(int id);
    Task<Veterinarians?> FindByEmail(int email);
}