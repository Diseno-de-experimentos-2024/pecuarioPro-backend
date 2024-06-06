using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Bovine
{
    public ICollection<ImageAsset> Images { get; }
    public BovineIdentifier BovineIdentifier { get; }

    public Bovine()
    {
        Images = new List<ImageAsset>();
        BovineIdentifier = new BovineIdentifier();
    }

    private bool ExistImageWithUrl(string imageUrl)
    {
        return Images.Any(a => (string)a.GetContent() == imageUrl);
    }
    
    public void AddImage(string imageUrl)
    {
        if (ExistImageWithUrl(imageUrl)) return;
        Images.Add(new ImageAsset(imageUrl));
    }
    
    
    
    
}