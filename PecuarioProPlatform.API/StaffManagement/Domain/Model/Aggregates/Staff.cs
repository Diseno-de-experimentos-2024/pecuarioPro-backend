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
    }

    public Staff(string firstName, string lastName, string email)
    {
        Name = new StaffName(firstName, lastName);
        Email = new EmailAddress(email);
    }

    public StaffName Name { get; private set; }
    public EmailAddress Email { get; private set; }
}
