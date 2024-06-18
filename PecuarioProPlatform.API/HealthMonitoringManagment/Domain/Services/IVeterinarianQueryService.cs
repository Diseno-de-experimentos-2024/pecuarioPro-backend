using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Queries;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;

public interface IVeterinarianQueryService
{
    Task<Veterinarians> Handle(GetVeterinariansByIdQuery query);
    Task<Veterinarians> Handle(GetVeterinariansBySpecialty query);
    Task<IEnumerable<Veterinarians>> Handle(GetAllVeterinariansQuery query);
}