using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Campaign
{
    public ECampaignCondition Condition { get; protected set; }
    public ICollection<Batch> Batches { get; }

    public Campaign()
    {
        Batches = new List<Batch>();
        Condition = ECampaignCondition.Inactive;
    }

    public void conditionActive()
    {
        
    }
    
}