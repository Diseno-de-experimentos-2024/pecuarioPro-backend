using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Repositories;

public interface IVeterinarianRepository : IBaseRepository<Veterinarians>
{
    
    Task<Veterinarians?> FindBySpecialty(string specialty);
    new Task<Veterinarians?> FindByIdAsync(int id);
}