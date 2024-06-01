namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.ValueObjects;

public record StaffName(string FirstName, string LastName)
{
    public StaffName() : this(string.Empty, string.Empty)
    {
    }

    public StaffName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
};