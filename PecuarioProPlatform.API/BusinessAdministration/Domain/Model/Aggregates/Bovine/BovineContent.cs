using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Bovine
{
    public ICollection<ImageAsset> Images { get; }
    public BovineIdentifier BovineIdentifier { get; }
    
    public ICollection<WeightRecord> WeightRecords { get; set; }

    public Bovine()
    {
        Images = new List<ImageAsset>();
        BovineIdentifier = new BovineIdentifier();
        WeightRecords = new List<WeightRecord>();
    }

    private bool ExistImageWithUrl(string imageUrl)
    {
        return Images.Any(a => (string)a.GetContent() == imageUrl);
    }

    private bool ExistWeightRecord(double weight, DateTime dateTime)
    {
        return WeightRecords.Any(w => w.GetWeight() == weight && w.GetRecordDate() == dateTime);
    }
    
    public void AddImage(string imageUrl)
    {
        if (ExistImageWithUrl(imageUrl)) return;
        Images.Add(new ImageAsset(imageUrl));
    }

    public void AddWeightRecord(double weight, DateTime dateTime)
    {
        if (ExistWeightRecord(weight, dateTime)) return;
        WeightRecords.Add(new WeightRecord(Id,weight,dateTime));
    }
    
    
    
}