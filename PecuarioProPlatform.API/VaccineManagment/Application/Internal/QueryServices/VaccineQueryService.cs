using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;

namespace PecuarioProPlatform.API.VaccineManagment.Application.Internal.QueryServices;

public class VaccineQueryService(IVaccineRepository vaccineRepository): IVaccineQueryService
{
    public async Task<IEnumerable<Vaccine>> Handle(GetAllVaccineQuery query)
    {
        return await vaccineRepository.ListAsync();
    }

    public async Task<Vaccine?> Handle(GetVaccineByIdQuery query)
    {
        return await vaccineRepository.FindByIdAsync(query.VaccineId);
    }

    public async Task<Vaccine?> Handle(GetVaccineByCodeQuery query)
    {
        return await vaccineRepository.FindVaccineByCodeAsync(query.Code);
    }
} 