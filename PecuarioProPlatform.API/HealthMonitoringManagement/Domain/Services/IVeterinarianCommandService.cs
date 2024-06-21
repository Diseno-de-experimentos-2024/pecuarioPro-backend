using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;

public interface IVeterinarianCommandService
{
    Task<Veterinarians> Handle(CreateVeterinarianCommand command);
    Task<Veterinarians> Handle(DeleteVeterinarianCommand command);
}