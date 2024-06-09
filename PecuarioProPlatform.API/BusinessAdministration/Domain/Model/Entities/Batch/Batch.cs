using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Batch
{
    public int Id { get; set; }
    public string Name { get;  set; }
    public double Area { get;  set; }
    public Campaign Campaign { get; set; }

    
    public Origin Origin { get; set; }
    public int CampaignId { get;  set; }

    public Batch(string _Name, double _Area , int campaignId, int districtId,int cityId,int departmentId)
    {
        Name = _Name;
        Area = _Area;
        Origin = new Origin(districtId, cityId, departmentId);
        CampaignId = campaignId;

    }
    
     public Batch(CreateBatchCommand command) :this(command.Name, command.Area,command.campaignId,command.districtId,command.cityId,command.departmentId){}
}