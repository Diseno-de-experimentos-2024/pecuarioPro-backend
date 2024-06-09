namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public record VaccineId(Guid Identifier)
{
    public VaccineId() : this(Guid.NewGuid())
    {
    }
};