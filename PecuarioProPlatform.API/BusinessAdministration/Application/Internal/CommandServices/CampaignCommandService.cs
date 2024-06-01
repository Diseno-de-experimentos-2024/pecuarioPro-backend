using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;

public class CampaignCommandService(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork):ICampaignCommandService
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
        
        try
        {
            campaign.AddBatch(batch);
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

    public async Task<Campaign?> Handle(DeleteBatchToCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);
        campaign.RemoveBatch(command.batchId);
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
   
    public async Task<Campaign?> Handle(ModifyDurationCampaignCommand command)
    {
        var campaign = await campaignRepository.FindByIdAsync(command.campaignId);

        try
        {
            if (command.duration < 0) throw new Exception("Duration is not valid");
            
            campaign.ModifyDuration(command.duration);
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

        try
        {
            campaign.UpdateCondition(command.condition);
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

        try
        {
            batch.UpdateStatus(command.status);
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