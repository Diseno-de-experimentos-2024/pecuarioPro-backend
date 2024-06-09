using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.CommandServices;

public class DistrictCommandService(IDistrictRepository districtRepository,ICityRepository cityRepository,IUnitOfWork unitOfWork) : IDistrictCommandService
{
    private IDistrictCommandService _districtCommandServiceImplementation;
    public async Task<District?> Handle(CreateDistrictCommand command)
    {
        var city = await  cityRepository.FindByIdAsync(command.CityId);
        var district = new District(command.Name, command.CityId);
        district.City = city;

        try
        {
            districtRepository.AddAsync(district);
            unitOfWork.CompleteAsync();
            return district;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a district:{e.Message} ");
            return null;
        }
        
    }
}