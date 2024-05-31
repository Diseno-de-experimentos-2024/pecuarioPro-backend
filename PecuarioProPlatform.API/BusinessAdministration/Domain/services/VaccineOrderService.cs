namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates.Vaccine;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public class VaccineOrderService
{
    private readonly IVaccineOrder _vaccineOrder;

    public VaccineOrderService(IVaccineOrder vaccineOrder)
    {
        _vaccineOrder = vaccineOrder;
    }

    public void CreateVaccineOrder(Guid id, string name, string reason, DateTime date, string code)
    {
        var vaccineOrder = new VaccineOrder(id, name, reason, date, code);
        _vaccineOrder.Add(vaccineOrder);
    }

    public void AddBovineVaccineToOrder(Guid vaccineOrderId, IdBovine bovineId, StaffId staffId)
    {
        var vaccineOrder = _vaccineOrder.GetById(vaccineOrderId);
        if (vaccineOrder != null)
        {
            vaccineOrder.AddBovineVaccine(bovineId, staffId);
        }
    }

    public VaccineOrder GetVaccineOrderById(Guid id)
    {
        return _vaccineOrder.GetById(id);
    }

    public IEnumerable<VaccineOrder> GetAllVaccineOrders()
    {
        return _vaccineOrder.GetAll();
    }
}
