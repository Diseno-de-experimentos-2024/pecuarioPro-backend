using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Repositories;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Application.Internal.CommandServices;

public class VeterinarianCommandService(IVeterinarianRepository veterinarianRepository, IUnitOfWork unitOfWork) : IVeterinarianCommandService
{
  public async Task<Veterinarians> Handle(CreateVeterinarianCommand command)
  {
    var veterinarian = new Veterinarians(command);
    try
    {
      await veterinarianRepository.AddAsync(veterinarian);
      await unitOfWork.CompleteAsync();
      return veterinarian;
    }
    catch (Exception e)
    {
      Console.WriteLine($"An error occurred while creating the veterinarian: {e.Message}");
      throw;
    }
  }

  public Task<Veterinarians> Handle(DeleteVeterinarianCommand command)
  {
    throw new NotImplementedException();
  }
}