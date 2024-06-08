

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;


public class BovineVaccine
{
    public int Id;
    public string VaccinationDate { get; private set; }
    public int BovineId { get; private set; }
    public Bovine Bovine { get; private set; }
    public StaffId StaffId { get; private set; }
    public VaccineId VaccineId { get; private set; }
    
    public BovineVaccine(int  bovineId)
    {
        VaccinationDate = DateTime.Now.ToString("yyyy-MM-dd");
        BovineId = bovineId;
        StaffId = new StaffId();
        VaccineId = new VaccineId();
    }
}