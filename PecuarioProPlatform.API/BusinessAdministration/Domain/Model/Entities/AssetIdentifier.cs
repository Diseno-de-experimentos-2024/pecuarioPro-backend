namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public record AssetIdentifier(Guid Identifier)
{
    public AssetIdentifier(): this(Guid.NewGuid()){}
}