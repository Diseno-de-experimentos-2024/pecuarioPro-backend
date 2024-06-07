using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;

namespace PecuarioProPlatform.API.Shared.Application.Internal.CommandServices;

public class CityCommandService(ICityRepository cityRepository, IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork): ICityCommandService
{
    private ICityCommandService _cityCommandServiceImplementation;
    public async Task<City?> Handle(CreateCityCommand command)
    {

        var city = new City(command.name,command.departmentId);
        var department = await departmentRepository.FindByIdAsync(command.departmentId);
        city.Department = department;
        try
        {
            await cityRepository.AddAsync(city);
            await unitOfWork.CompleteAsync();
            return city;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a city:{e.Message} ");
            return null;
        }
    }
}