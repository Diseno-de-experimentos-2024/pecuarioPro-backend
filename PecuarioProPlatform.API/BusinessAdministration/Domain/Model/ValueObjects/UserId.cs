namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public record  UserId(Guid Identifier)
{
    public UserId() : this(Guid.NewGuid())
    {
    }
}