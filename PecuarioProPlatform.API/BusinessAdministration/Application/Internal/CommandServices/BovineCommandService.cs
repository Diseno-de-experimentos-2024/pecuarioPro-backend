using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;

public class BovineCommandService(IBovineRepository bovineRepository,IDistrictRepository districtRepository,
    ICityRepository cityRepository,
    IDepartmentRepository departmentRepository,
    IRaceRepository raceRepository,
    IUnitOfWork unitOfWork) :IBovineCommandService
{
    private IBovineCommandService _bovineCommandServiceImplementation;
    

    public async Task<Bovine?> Handle(CreateBovineCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.DistrictId);
        var city =await cityRepository.FindByIdAsync(command.CityId);
        var department = await departmentRepository.FindByIdAsync(command.DepartmentId);
        var race = await  raceRepository.FindByIdAsync(command.RaceId);
        var bovine = new Bovine(command);
        // bovine.Origin = new Origin(district.Id, district, city.Id, city, department.Id, department);
        bovine.Origin.District = district;
        bovine.Origin.City = city;
        bovine.Origin.Department = department;
        bovine.Race = race;
        try
        {
            await bovineRepository.AddAsync(bovine);
            await unitOfWork.CompleteAsync();
            return bovine;

        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a bovine:{e.Message} ");
            return null;
        }
    }

    
    public async  Task<Bovine?> Handle(AddImageAssetToBovineCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        if (bovine is null) throw new Exception("Bovine not found");
        bovine.AddImage(command.urlImage);
        try
        {
            await unitOfWork.CompleteAsync();
            return bovine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while adding the image to the bovine: {e.Message}");
            return null;
        }
    }
    

    public async Task<Bovine?> Handle(ModifyWeightBovineCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        if (bovine is null) throw new Exception("Bovine not found");
        bovine.SetWeight(command.weight);

        try
        {
            await unitOfWork.CompleteAsync();
            return bovine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when modifying the weight of the bovine.: {e.Message}");
            return null;
        }

    }

    public async Task<Bovine> Handle(AddBovineToBatchCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        if (bovine is null) throw new Exception("Bovine not found");
        bovine.SetBatch(command.batchId); 
        try
        {
            await unitOfWork.CompleteAsync();
            return bovine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when aggregate bovine to the batch.: {e.Message}");
            return null;
        }
    }

    public async Task<Bovine> Handle(DeleteBovineToBatchCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        if (bovine is null) throw new Exception("Bovine not found");
        bovine.SetBatch(0); 
        try
        {
            await unitOfWork.CompleteAsync();
            return bovine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when delete bovine to the batch.: {e.Message}");
            return null;
        }
    }

    public async Task<Bovine?> Handle(AddWeightRecordToBovineCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        if (bovine is null) throw new Exception("Bovine not found");
        bovine.AddWeightRecord(command.weight,command.DateTime);
        try
        {
            await unitOfWork.CompleteAsync();
            return bovine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when delete bovine to the batch.: {e.Message}");
            return null;
        }

    }
}