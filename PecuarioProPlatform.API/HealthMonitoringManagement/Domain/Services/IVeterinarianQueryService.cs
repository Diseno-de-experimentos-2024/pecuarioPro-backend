using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Queries;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;

public interface IVeterinarianQueryService
{
    Task<Veterinarian?> Handle(GetVeterinariansByIdQuery query);
    Task<Veterinarian?> Handle(GetVeterinariansBySpecialty query);
    Task<IEnumerable<Veterinarian>> Handle(GetAllVeterinariansQuery query);
}