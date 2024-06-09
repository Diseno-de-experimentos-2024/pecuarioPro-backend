namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public record BovineIdentifier(Guid Identifier)
{
    public BovineIdentifier(): this(Guid.NewGuid()){}
}