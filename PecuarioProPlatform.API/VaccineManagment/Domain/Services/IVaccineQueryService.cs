using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Services;

public interface IVaccineQueryService
{
    Task<Vaccines?> Handle(GetVaccinesByCode query);
    Task<Vaccines?> Handle(GetVaccinesByName query);
    Task<Vaccines?> Handle(GetVaccineByIdQuery query);
    Task<Vaccines?> Handle(GetVaccinesByNameAndCode query);
    Task<IEnumerable<Vaccines>> Handle(GetAllVaccinesQuery query);
}