

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;


public class BovineVaccine
{
    
    public IdBovine IdBovine { get; private set; }
    public StaffId StaffId { get; private set; }

    public BovineVaccine(IdBovine bovineId, StaffId staffId)
    {
        IdBovine = bovineId;
        StaffId = staffId;
    }
}