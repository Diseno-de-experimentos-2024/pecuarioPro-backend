using System.Runtime.CompilerServices;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class BovineResourceFromEntityAssembler
{
    public static BovineResource ToResourceFromEntity(Bovine entity)
    {
        
        var imageUrls = entity.Images.Select(image => image.GetContent()).ToList();
        Console.WriteLine(imageUrls);

        return new BovineResource(
            entity.Id,
            entity.BovineIdentifier.Identifier.ToString(),
            entity.Name,
            entity.Weight,
            entity.Date,
            entity.Observations,
            OriginResourceFromEntityAssembler.ToResourceFromEntity(entity.Origin),
            entity.Breed.Name,
            entity.BatchId,
            entity.UserId.Identifier,
            imageUrls
            );
    }
}