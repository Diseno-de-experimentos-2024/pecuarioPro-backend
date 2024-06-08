using System.Collections;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;

namespace PecuarioProPlatform.API.VaccineManagment.Application.Internal.QueryServices;

public class VaccineQueryService(IVaccineRepository vaccineRepository) : IVaccineQueryService
{
    public async Task<Vaccines?> Handle(GetVaccinesByCode query)
    {
        return await vaccineRepository.FindByCodeAsync(query.Code);
    }

    public async Task<Vaccines?> Handle(GetVaccinesByName query)
    {
        return await vaccineRepository.FindByNameAsync(query.Name);
    }

    public async Task<Vaccines?> Handle(GetVaccineByIdQuery query)
    {
        return await vaccineRepository.FindByIdAsync(query.IdVaccine);
    }

    public async Task<Vaccines?> Handle(GetVaccinesByNameAndCode query)
    {
        return await vaccineRepository.FindByNameAndCodeAsync(query.Name, query.Code);
    }

    public async Task<IEnumerable<Vaccines>> Handle(GetAllVaccinesQuery query)
    {
        return await vaccineRepository.ListAsync();
    }
}