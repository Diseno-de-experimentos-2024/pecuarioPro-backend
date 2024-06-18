using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;

public interface IVeterinarianCommandService
{
    Task<Veterinarians> Handle(CreateVeterinarianCommand command);
    Task<Veterinarians> Handle(DeleteVeterinarianCommand command);
}