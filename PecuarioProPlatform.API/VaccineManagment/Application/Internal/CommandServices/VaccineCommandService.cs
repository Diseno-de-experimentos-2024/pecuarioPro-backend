using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;

namespace PecuarioProPlatform.API.VaccineManagment.Application.Internal.CommandServices;

public class VaccineCommandService(IVaccineRepository vaccineRepository, IUnitOfWork unitOfWork) : IVaccineCommandService
{
    public async Task<Vaccine?> Handle(CreateVaccineCommand command)
    {
        var vaccine = new Vaccine(command);
        try
        {
            await vaccineRepository.AddAsync(vaccine);
            await unitOfWork.CompleteAsync();
            return vaccine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the vaccine: {e.Message}");
            return null;
        }
    }

    public async Task<Vaccine?> Handle(UpdateVaccineCommand command)
    {
        var vaccine = await vaccineRepository.FindByIdAsync(command.Id);
        vaccine?.updateInformation(command.Name, command.Date, command.Code, command.Reason,command.Dose);
        try
        {
            await unitOfWork.CompleteAsync();
            return vaccine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the vaccine: {e.Message}");
            return null;
        }
    }

    public async Task<Vaccine?> Handle(DeleteVaccineCommand command)
    {
        var vaccine = await vaccineRepository.FindVaccineByIdAsync(command.Id);
        if (vaccine is null) return null;

        vaccineRepository.Remove(vaccine);

        try
        {
            await unitOfWork.CompleteAsync();
            return vaccine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the vaccine: {e.Message}");
            return null;
        }
    }
}