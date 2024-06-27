using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;

/**
 * Staff aggregate root entity
 */

public partial class Staff
{
    public int Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string JobDescription { get; private set; }
    public int PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string City { get; private set; }
    public string Status { get; private set; }
    public string PhotoUrl { get; private set; }
    
    
    public Staff(string firstName, string lastName, string jobDescription,  
        int phoneNumber, string email, string city, string status, string photoUrl)
    {
        FirstName = firstName;
        LastName = lastName;
        JobDescription = jobDescription;
        PhoneNumber = phoneNumber;
        Email = email;
        City = city;
        Status = status;
        PhotoUrl = photoUrl;
    }

    public Staff(CreateStaffCommand command) : this(
        command.FirstName,
        command.LastName,
        command.JobDescription,
        command.PhoneNumber,
        command.Email,
        command.City,
        command.Status,
        command.PhotoUrl)
    {}
    
}
