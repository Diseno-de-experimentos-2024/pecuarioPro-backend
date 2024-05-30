namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Campaign
{
    public int Id { get; }
    public string Name { get; private set; }
    public DateOnly DateStart { get; private set; }
    public DateOnly DateEnd { get; private set; }
    public string Objective { get; private set; }

    public Campaign(string _Name, DateOnly _DateStart, DateOnly _DateEnd, string _Objective) : this()
    {
        Name = _Name;
        DateStart = _DateStart;
        DateEnd = _DateEnd;
        Objective = _Objective;
    }
    
    
    
    // public Campaign(CreateCampaignCommand command) : this(command.Name, command.DateStart, command.DateEnd, command.Objective){}
    
}