using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Entities;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;

public interface IVeterinarianCommandService
{
    Task<Veterinarians> Handle(CreateVeterinarianCommand command);
    Task<Veterinarians> Handle(DeleteVeterinarianCommand command);
}