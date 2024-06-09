using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public class WeightRecord
{
    public int Id { get; set; }
    public int BovineId { get; set; }
    public Bovine Bovine { get; set; }
    public double Weight { get; set; }
    public DateTime RecordDate { get; set; }
    
    public WeightRecord(){}

    public WeightRecord(int bovineId, double weight, DateTime recordDate)
    {
        this.BovineId = bovineId;
        this.Weight = weight;
        this.RecordDate = recordDate;
    }
    
    public double GetWeight()
    {
        return Weight;
    }

    public DateTime GetRecordDate()
    {
        return RecordDate;
    }
}