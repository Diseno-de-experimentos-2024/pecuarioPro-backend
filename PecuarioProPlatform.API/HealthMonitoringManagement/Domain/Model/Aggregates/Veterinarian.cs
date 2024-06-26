using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;

public partial class Veterinarian
{
    public int Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Specialty { get; private set; }
    public int PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string City { get; private set; }
    public string Status { get; private set; }
    public string PhotoUrl { get; private set; }
    
    
    public Veterinarian(string firstName, string lastName, string specialty,  
        int phoneNumber, string email, string city, string status, string photoUrl)
    {
        FirstName = firstName;
        LastName = lastName;
        Specialty = specialty;
        PhoneNumber = phoneNumber;
        Email = email;
        City = city;
        Status = status;
        PhotoUrl = photoUrl;
    }

    public Veterinarian(CreateVeterinarianCommand command) : this(
        command.FirstName,
        command.LastName,
        command.Specialty,
        command.PhoneNumber,
        command.Email,
        command.City,
        command.Status,
        command.PhotoUrl)
    {}
}