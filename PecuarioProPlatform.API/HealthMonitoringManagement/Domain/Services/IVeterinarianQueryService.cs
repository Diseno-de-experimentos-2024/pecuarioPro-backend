using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Queries;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;

public interface IVeterinarianQueryService
{
    Task<Veterinarians?> Handle(GetVeterinariansByIdQuery query);
    Task<Veterinarians?> Handle(GetVeterinariansBySpecialty query);
    Task<IEnumerable<Veterinarians>> Handle(GetAllVeterinariansQuery query);
}