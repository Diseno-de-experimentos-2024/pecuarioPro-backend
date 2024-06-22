using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;

public class BreedCommandService(IBreedRepository breedRepository,IUnitOfWork unitOfWork): IBreedCommandService
{
    private IBreedCommandService _breedCommandServiceImplementation;
    public async Task<Breed?> Handle(CreateBreedCommand command)
    {
        var race = new Breed(command.name);

        try
        {
            await breedRepository.AddAsync(race);
            await unitOfWork.CompleteAsync();
            return race;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a race:{e.Message} ");
            return null;
        }
    }
}