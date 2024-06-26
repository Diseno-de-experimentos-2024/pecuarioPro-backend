using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Application.Internal.CommandServices;

public class VeterinarianCommandService(IVeterinarianRepository veterinarianRepository, IUnitOfWork unitOfWork) : IVeterinarianCommandService
{
  public async Task<Veterinarians?> Handle(CreateVeterinarianCommand command)
  {
    var veterinarian = new Veterinarians(command);
    try
    {

      await veterinarianRepository.AddAsync(veterinarian);
      await unitOfWork.CompleteAsync();
      return veterinarian;
    }
    catch
    {
      return null;
    }
  }
  public Task<Veterinarians> Handle(DeleteVeterinarianCommand command)
  {
    throw new NotImplementedException();
  }
}