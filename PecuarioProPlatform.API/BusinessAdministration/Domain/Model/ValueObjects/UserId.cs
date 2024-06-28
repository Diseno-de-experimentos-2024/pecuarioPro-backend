namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public record  UserId(int Identifier)
{
    public UserId() : this(0)
    {
    }
}