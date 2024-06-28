using PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;

/**
 * Staff aggregate root entity
 */

public partial class Staff
{
    public int Id { get; }
    
    /*
     * campaign id
     */
    public string CampaignId { get; private set; } //sin
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    
    public string Status { get; private set; }
    
    public string JobDescription { get; private set; }
    
    // date start
    public string DateStart { get; private set; } //sin
    
    // date end
    public string DateEnd { get; private set; } //sin
    
    
    public Staff(string campaignId, string firstName, string lastName, string jobDescription,  
        string email, string status, string dateStart, string dateEnd)
    {
        CampaignId = campaignId;
        FirstName = firstName;
        LastName = lastName;
        JobDescription = jobDescription;
        Email = email;
        Status = status;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }

    public Staff(CreateStaffCommand command) : this(
        command.CampaignId,
        command.FirstName,
        command.LastName,
        command.JobDescription,
        command.Email,
        command.Status,
        command.DateStart,
        command.DateEnd)
    {}
    
}
