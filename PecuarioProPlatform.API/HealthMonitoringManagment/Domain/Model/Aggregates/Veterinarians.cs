using System.ComponentModel.DataAnnotations;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;

public class Veterinarians
{

    public int Id { get; }
    
    [Required]
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Specialty { get; private set; }
    public int PhoneNumber { get; private set; }
    public long Email { get; private set; }
    public string PhotoUrl { get; private set; }
    
    
    public Veterinarians(int id, string firstName, string lastName, string specialty,  int phoneNumber, long email, string photoUrl)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Specialty = specialty;
        PhoneNumber = phoneNumber;
        Email = email;
        PhotoUrl = photoUrl;
    }

    public Veterinarians(CreateVeterinarianCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Specialty = command.Specialty;
        PhoneNumber = command.PhoneNumber;
        Email = command.Email;
        PhotoUrl = command.PhotoUrl;
    }
}