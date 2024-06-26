using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Services;

public interface IVaccineQueryService
{
    Task<IEnumerable<Vaccine>> Handle(GetAllVaccineQuery query);
    Task<Vaccine?> Handle(GetVaccineByIdQuery query);
    Task<Vaccine?> Handle(GetVaccineByCodeQuery query);
}