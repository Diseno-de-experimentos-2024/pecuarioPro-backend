namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects;

public record  UserId(int Identifier)
{
    public UserId() : this(0)
    {
    }
}