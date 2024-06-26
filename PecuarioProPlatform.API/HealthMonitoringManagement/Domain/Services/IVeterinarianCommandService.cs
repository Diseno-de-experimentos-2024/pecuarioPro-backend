using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;

public interface IVeterinarianCommandService
{
    Task<Veterinarian?> Handle(CreateVeterinarianCommand command);
    Task<Veterinarian?> Handle(DeleteVeterinarianCommand command);
}