using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;

namespace PecuarioProPlatform.API.VaccineManagment.Application.Internal.CommandServices;

public class VaccineCommandService(IVaccineRepository vaccineRepository, IUnitOfWork unitOfWork) : IVaccineCommandService
{
    public async Task<Vaccines?> Handle(CreateVaccineCommand command)
    {
        var vaccine = new Vaccines(command);
        try
        {
            await vaccineRepository.AddAsync(vaccine);
            await unitOfWork.CompleteAsync();
            return vaccine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the vaccine: {e.Message}");
            throw;
        }
    }
}