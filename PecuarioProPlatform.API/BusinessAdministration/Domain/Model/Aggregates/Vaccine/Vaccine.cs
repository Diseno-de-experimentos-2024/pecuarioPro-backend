namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public class Vaccine
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Reason { get; private set; }
    public string Code { get; private set; }
    public DateOnly Date { get; private set; }
    
    public Bovine Bovine { get; }
    public int BovineId { get; private set; }

    public Vaccine(string name, string reason, string code,DateOnly date, int bovineId)
    {
        Name = name;
        Reason = reason;
        Code = code;
        Date = date;
        BovineId = bovineId;
    }
}