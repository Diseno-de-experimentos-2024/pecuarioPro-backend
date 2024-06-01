namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

public record CreateStaffCommand(string FirstName, string LastName, string Email);