using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;

public class RaceCommandService(IRaceRepository raceRepository,IUnitOfWork unitOfWork): IRaceCommandService
{
    private IRaceCommandService _raceCommandServiceImplementation;
    public async Task<Race?> Handle(CreateRaceCommand command)
    {
        var race = new Race(command.name);

        try
        {
            await raceRepository.AddAsync(race);
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