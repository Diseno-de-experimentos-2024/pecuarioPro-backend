using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class BovineResourceFromEntityAssembler
{
    public static BovineResource ToResourceFromEntity(Bovine entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (entity.District == null) throw new ArgumentNullException(nameof(entity.District));
        if (entity.Race == null) throw new ArgumentNullException(nameof(entity.Race));
        
        Console.WriteLine($"Converting Bovine to Resource: {entity.Id}, {entity.Name}, {entity.Weight}, {entity.Date}, {entity.Observations}, {entity.District.Name}, {entity.Race.Name}");

        
        return new BovineResource(entity.Id, entity.BovineIdentifier.ToString(), entity.Name, entity.Weight, entity.Date,
            entity.Observations, entity.District.Name, entity.Race.Name);
    }
}