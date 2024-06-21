using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;

/**
 * Staff aggregate root entity
 */

public partial class Staff
{
    public Staff()
    {
        Name = new StaffName();
        Email = new EmailAddress();
        Address = new StaffAddress();
    }

    public Staff(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        Name = new StaffName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StaffAddress(street, number, city, postalCode, country);
    }
    
    public Staff(CreateStaffCommand command)
    {
        Name = new StaffName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StaffAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
    }

    public StaffName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StaffAddress Address { get; private set; }
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    
    public string StreetAddress => Address.FullAddress;
    
}
