using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Campaign
{
    public ECampaignCondition Condition { get; protected set; }
    public int Duration { get; protected set; }
    public ICollection<Batch> Batches { get; set; }
    
    public UserId UserId { get; }

    public Campaign()
    {
        Batches = new List<Batch>();
        Condition = ECampaignCondition.Inactive;
        UserId = new UserId(); 
      
    }

    public void ConditionActive()
    {
        Condition = ECampaignCondition.Active;
    }
    
    public void ConditionInactive()
    {
        Condition = ECampaignCondition.Inactive;
    }

    public void ConditionFinished()
    {
        Condition = ECampaignCondition.Finished;
    }

    public void UpdateCondition(ECampaignCondition condition)
    {
        Condition = condition;
    }

    public void UpdateInformation(UpdateCampaignCommand command)
    {
        this.Name = command.name;
        this.DateStart = command.dateStart;
        this.DateEnd = command.dateEnd;
        this.Objective = command.objective;
        this.CalculateDuration();
        var date = new DateOnly();
        if (date >= DateEnd)
        {
            this.UpdateCondition("Finished");

        }
    }
    public void UpdateCondition(string condition)
    {
      
            switch (condition)
            {
                case "Inactive":
                   ConditionInactive();
                    break;
                case "Active":
                   ConditionActive();
                    break;
                case "Finished":
                    ConditionFinished();
                    break;
                default:
                    throw new ArgumentException("Estado no válido", nameof(condition));
            }
        
    }
    

    private void CalculateDuration()
    {
        Duration = (DateEnd.DayNumber - DateStart.DayNumber);

    }

    public void AddBatch(Batch batch)
    {
        if (batch != null)
            Batches.Add(batch);
    }

    public void RemoveBatch(int batchId)
    {
        var batchToRemove = Batches.FirstOrDefault(b => b.Id == batchId);
        if (batchToRemove != null)
            Batches.Remove(batchToRemove);
    }

    public void ClearBatches() => Batches.Clear();

    public int CountBatchesByStatus(string status)
    {
        return Batches.Count(batch => batch.Status.ToString() == status);
    }

    public double CalculateAdverageBatchesStatus(string status)
    {
        if (Batches.Count > 0)
        {
            return CountBatchesByStatus(status) / Batches.Count;
        } return 0;
    }

    public void ModifyDuration(int duration)
    {
        Duration = duration;
        DateEnd = DateStart.AddDays(duration);
    }


}