namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

public record CreateStaffResource(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);