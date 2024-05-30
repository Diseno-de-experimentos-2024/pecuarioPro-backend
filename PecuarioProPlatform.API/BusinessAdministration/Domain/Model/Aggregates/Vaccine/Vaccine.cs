namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public class Vaccine(string name, string reason, string code, DateOnly date)
{
    public int Id { get; }
    public string Name { get; private set; } = name;
    public string Reason { get; private set; } = reason;
    public string Code { get; private set; } = code;
    public DateOnly Date { get; private set; } = date;

    // public Bovine Bovine { get; }
    // public int BovineId { get; private set; }
}