namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates.Vaccine;

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;
    
public interface IVaccineOrder
{
    void Add(VaccineOrder vaccineOrder);
    VaccineOrder GetById(Guid id);
    IEnumerable<VaccineOrder> GetAll();
}