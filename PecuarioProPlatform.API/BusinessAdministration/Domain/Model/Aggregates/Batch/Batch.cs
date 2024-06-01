using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Batch
{
    public int Id { get; }
    public string Name { get; private set; }
    public double Area { get; private set; }
    
    public District District { get; }
    
    public Campaign Campaign { get; }
    public int CampaignId { get; private set; }
    public int DistrictId { get; private set; }
    

    public Batch(string _Name, double _Area , int campaignId, int districtId)
    {
        Name = _Name;
        Area = _Area;
        DistrictId = districtId;
    }
    
    // public Batch(CreateBatchCommand command) :this(command.Name, command.Area, command.CampaignId){}
}