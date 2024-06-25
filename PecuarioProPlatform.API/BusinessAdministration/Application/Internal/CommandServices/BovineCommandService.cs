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
    IBreedRepository breedRepository,
    IUnitOfWork unitOfWork) :IBovineCommandService
{
    private IBovineCommandService _bovineCommandServiceImplementation;
    

    public async Task<Bovine?> Handle(CreateBovineCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.DistrictId);
        var city =await cityRepository.FindByIdAsync(command.CityId);
        var department = await departmentRepository.FindByIdAsync(command.DepartmentId);
        var breed = await  breedRepository.FindByIdAsync(command.RaceId);
        var bovine = new Bovine(command);
        // bovine.Origin = new Origin(district.Id, district, city.Id, city, department.Id, department);
        bovine.Origin.District = district;
        bovine.Origin.City = city;
        bovine.Origin.Department = department;
        bovine.Breed = breed;
        
        foreach (var url in command.Urls)
        {
            bovine.AddImage(url);
        }
        
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

    public async Task<Bovine?> Handle(UpdateBovineCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.districtId);
        var city =await cityRepository.FindByIdAsync(command.cityId);
        var department = await departmentRepository.FindByIdAsync(command.departmentId);
        var breed = await  breedRepository.FindByIdAsync(command.breedId);

        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);
        bovine.Origin.District = district;
        bovine.Origin.City = city;
        bovine.Origin.Department = department;
        bovine.Breed = breed;
        bovine.updateInformation(command.name,command.weight,command.date,command.observations,command.breedId,command.batchId);
     
        var listImageToRemove = bovine.Images.ToList();
        foreach (var image in listImageToRemove)
        {
            bovine.RemoveAsset(image.Id);
            bovineRepository.RemoveAssets(image);
        }
        
        foreach (var url in command.imgUrls)
        {
            bovine.AddImage(url);
        }
        
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

    public async Task<Bovine?> Handle(DeleteBovineCommand command)
    {
        var bovine = await bovineRepository.FindByIdAsync(command.bovineId);

        if (bovine == null)
        {
            return null; 
        }

        bovineRepository.Remove(bovine);

        try
        {
            await unitOfWork.CompleteAsync();
            return bovine; 
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting bovine: {e.Message}");
            throw new Exception("Error deleting bovine", e);
        }
    }
}