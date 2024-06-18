using System.ComponentModel.DataAnnotations;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Aggregates;

public class Veterinarians
{

    public int Id { get; }
    
    [Required]
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int VetPermit { get; private set; }
    public int ContactNumber { get; private set; }
    public bool Status { get; private set; }
    public string Specialty { get; private set; }
    
    public Veterinarians(int id, string firstName, string lastName, int vetPermit, int contactNumber, bool status, string specialty)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        VetPermit = vetPermit;
        ContactNumber = contactNumber;
        Status = status;
        Specialty = specialty;
    }

    public Veterinarians(CreateVeterinarianCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        VetPermit = command.VetPermit;
        ContactNumber = command.ContactNumber;
        Status = command.Status;
        Specialty = command.Specialty;
    }
}