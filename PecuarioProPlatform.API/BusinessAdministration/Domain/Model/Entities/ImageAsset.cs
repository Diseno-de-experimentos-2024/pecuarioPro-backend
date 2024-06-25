using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public class ImageAsset :IEntityWithCreatedUpdatedDate
{
    
    public int Id { get; private set; }
    public AssetIdentifier _AssetIdentifier { get; private set; }
    
    public string Name { get; private set; }
    public Uri? ImageUri { get; set; }
    // public int BovineId { get; private set; }
    // public Bovine Bovine { get; private set; }


    public string GetContent()
    {
        return ImageUri?.AbsoluteUri ?? string.Empty;
    }

    public ImageAsset()
    {
        _AssetIdentifier = new AssetIdentifier();
        Name = String.Empty;

    }
    public ImageAsset(string imageUrl):this()
    {
        ImageUri = new Uri(imageUrl) ;
    }

    public void updateUrl(Uri imgUrl)
    {
        this.ImageUri = imgUrl;
    }

     [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
     [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}