using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Campaign
{
    public ECampaignCondition Condition { get; protected set; }
    public int Duration { get; protected set; }
    public ICollection<Batch> Batches { get; }
    
    public UserId UserId { get; }

    public Campaign()
    {
        Batches = new List<Batch>();
        Condition = ECampaignCondition.Inactive;
        UserId = new UserId(); 
        CalculateDuration();
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

    public void CalculateDuration()
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

    public void calculateDuration()
    {
        Duration = (DateEnd.DayNumber - DateStart.DayNumber);
        
    }

    public void ModifyDuration(int duration)
    {
        Duration = duration;
        DateEnd = DateStart.AddDays(duration);
    }


}