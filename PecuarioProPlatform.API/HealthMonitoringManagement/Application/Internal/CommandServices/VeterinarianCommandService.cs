using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Application.Internal.CommandServices;

public class VeterinarianCommandService(IVeterinarianRepository veterinarianRepository, IUnitOfWork unitOfWork) : IVeterinarianCommandService
{
  public async Task<Veterinarian?> Handle(CreateVeterinarianCommand command)
  {
    var veterinarian = new Veterinarian(command);
    try
    {
      await veterinarianRepository.AddAsync(veterinarian);
      await unitOfWork.CompleteAsync();
      return veterinarian;
    }
    catch (Exception e)
    {
      Console.WriteLine($"An error occurred while creating a veterinarian:{e.Message}");
      return null;
    }
  }
  public async Task<Veterinarian?> Handle(DeleteVeterinarianCommand command)
  {
    var veterinarian = await veterinarianRepository.FindByIdAsync(command.VeterinarianId);
    if (veterinarian == null)
    {
      return null;
    }
    veterinarianRepository.Remove(veterinarian);

    try
    {
      await unitOfWork.CompleteAsync();
      return veterinarian;
    }
    catch (Exception e)
    {
      Console.WriteLine($"Error deleting veterinarian: {e.Message}");
      throw new Exception("Error deleting veterinarian, e");
    }
  }
}