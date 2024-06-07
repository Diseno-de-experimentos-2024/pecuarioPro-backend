using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class OriginResourceFromEntityAssembler
{
    public static OriginResource ToResourceFromEntity(Origin entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        Console.WriteLine($"Origin: DistrictId={entity.DistrictId},District = {entity.District}, CityId={entity.CityId},City = {entity.City}, DepartmentId={entity.DepartmentId},Department = {entity.Department}");
        if (entity.District != null) Console.WriteLine($"District: {entity.District.Name}");
        if (entity.City != null) Console.WriteLine($"City: {entity.City.Name}");
        if (entity.Department != null) Console.WriteLine($"Department: {entity.Department.Name}");
        
        
        Console.WriteLine(entity);
        // return new OriginResource(entity.District.Name, entity.City.Name, entity.Department.Name);
        return new OriginResource(
            entity.District?.Name ?? "Unknown",
            entity.City?.Name ?? "Unknown",
            entity.Department?.Name ?? "Unknown"
        );
    }
}