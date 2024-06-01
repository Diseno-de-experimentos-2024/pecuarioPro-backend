

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;


public class BovineVaccine
{
    public int Id;
    public int BovineId { get; private set; }
    public Bovine Bovine { get; private set; }
    public StaffId StaffId { get; private set; }
    
    public BovineVaccine(int  bovineId)
    {
        BovineId = bovineId;
        StaffId = new StaffId();
    }
}