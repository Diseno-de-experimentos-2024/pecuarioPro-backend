using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;

public class CampaignCommandService(ICampaignRepository campaignRepository,IDistrictRepository districtRepository,
    ICityRepository cityRepository,
    IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork):ICampaignCommandService
{
    public async Task<Campaign?> Handle(CreateCampaignCommand command)
    {
        var campaign = new Campaign(command);

        try
        {
            await campaignRepository.AddAsync(campaign);
            await unitOfWork.CompleteAsync();
            return campaign;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a campaign:{e.Message} ");
            return null;
        }

    }

    public async Task<Campaign?> Handle(AddBatchToCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        if (campaign is null) throw new Exception("Campaign not found");
        var batch = await campaignRepository.FindByBatchIdAndCampaignId(command.batchId, campaign.Id);
        campaign.AddBatch(batch);

        
        try
        {
            await unitOfWork.CompleteAsync();
            return campaign;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    

    public async Task<Campaign?> Handle(ConcludeCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        campaign.ConditionFinished();
        try
        {
            await unitOfWork.CompleteAsync();
            return campaign;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<IEnumerable<Batch>> Handle(DeleteBatchToCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId); 
        var batchRemove = campaign.Batches.FirstOrDefault(batch => batch.Id == command.batchId);
        campaign.RemoveBatch(command.batchId);
        campaignRepository.RemoveBatch(batchRemove);
        var batches = campaign.Batches;

        try
        {
            await unitOfWork.CompleteAsync();
            return batches;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }


    public async Task<IEnumerable<Campaign>> Handle(DeleteCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        campaignRepository.Remove(campaign);
        var campaigns = await campaignRepository.ListAsync();

        try
        {
            await unitOfWork.CompleteAsync();
            return campaigns;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Campaign?> Handle(ModifyDurationCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        if (command.duration < 0) throw new Exception("Duration is not valid");
            
        campaign.ModifyDuration(command.duration);
        
        try
        {
           
            await unitOfWork.CompleteAsync();
            return campaign;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
    }

    public async Task<Campaign?> Handle(UpdateConditionCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        campaign.UpdateCondition(command.condition);

        try
        {
            await unitOfWork.CompleteAsync();
            return campaign;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
      
    }

    public async Task<Batch?> Handle(UpdateStatusBatchCommand command)
    {
        var batch = await campaignRepository.FindByBatchIdAndCampaignId(command.batchId, command.campaignId);
        batch.UpdateStatus(command.status);
        try
        {
            await unitOfWork.CompleteAsync();
            return batch;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async  Task<Batch?> Handle(CreateBatchCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.districtId);
        Console.WriteLine(district);
        var city =await cityRepository.FindByIdAsync(command.cityId);
        var department = await departmentRepository.FindByIdAsync(command.departmentId);
        var batch = new Batch(command);
        batch.Campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        batch.Origin.District = district;
        batch.Origin.City = city;
        batch.Origin.Department = department;  
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        if (campaign is null) throw new Exception("Campaign not found");
        campaign.AddBatch(batch);
        try
        {
            await campaignRepository.AddAsync(campaign);
            await unitOfWork.CompleteAsync();
            return batch;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<Campaign?> Handle(UpdateCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        campaign.UpdateInformation(command);

        try
        {
            await unitOfWork.CompleteAsync();
            return campaign;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<Batch?> Handle(UpdateBatchCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        var batch = campaign.Batches.FirstOrDefault(batch => batch.Id == command.batchId);
        
        batch.UpdateInformation(command);
        
        var district = await districtRepository.FindByIdAsync(command.districtId);
        var city =await cityRepository.FindByIdAsync(command.cityId);
        var department = await departmentRepository.FindByIdAsync(command.departmentId);
        var origin = new Origin(district.Id, district, city.Id, city, department.Id, department);
        batch.Origin = origin;
        try
        {
            await unitOfWork.CompleteAsync();
            return batch;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}