using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Bovine
{
    public ICollection<ImageAsset> Images { get; }

    public Bovine()
    {
        Images = new List<ImageAsset>();
    }
    
    
}