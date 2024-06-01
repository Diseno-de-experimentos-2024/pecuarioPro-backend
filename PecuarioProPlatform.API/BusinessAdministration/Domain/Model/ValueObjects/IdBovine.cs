namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public class IdBovine
{
    public Guid Value { get; private set; }

    public IdBovine(Guid value)
    {
        Value = value;
    }
}