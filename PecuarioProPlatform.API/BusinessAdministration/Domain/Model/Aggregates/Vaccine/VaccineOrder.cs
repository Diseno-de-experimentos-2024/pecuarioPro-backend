namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;


public class VaccineOrder
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Reason { get; private set; }
    public DateTime Date { get; private set; }
    public string Code { get; private set; }
    public List<BovineVaccine> BovineVaccines { get; set; }

    public VaccineOrder(Guid id, string name, string reason, DateTime date, string code)
    {
        Id = id;
        Name = name;
        Reason = reason;
        Date = date;
        Code = code;
        BovineVaccines = new List<BovineVaccine>();
    }

    public void AddBovineVaccine(int bovineId, StaffId staffId)
    {
        var bovineVaccine = new BovineVaccine(bovineId);
        BovineVaccines.Add(bovineVaccine);
    }
}