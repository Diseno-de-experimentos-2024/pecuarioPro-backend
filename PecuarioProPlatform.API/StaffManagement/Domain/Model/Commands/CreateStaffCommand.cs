namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

public record CreateStaffCommand(string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);