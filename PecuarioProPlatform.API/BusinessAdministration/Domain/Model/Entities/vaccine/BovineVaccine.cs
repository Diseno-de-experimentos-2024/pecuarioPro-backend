

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;

public class BovineVaccine
{
    
    public BovineId BovineId { get; private set; }
    public StaffId StaffId { get; private set; }

    public BovineVaccine(BovineId bovineId, StaffId staffId)
    {
        BovineId = bovineId;
        StaffId = staffId;
    }
}