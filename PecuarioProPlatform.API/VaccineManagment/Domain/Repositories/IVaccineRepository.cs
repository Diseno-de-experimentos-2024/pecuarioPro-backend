using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

public interface IVaccineRepository: IBaseRepository<Vaccine>
{
    Task<Vaccine?> FindVaccineByCodeAsync(string code);
    Task<Vaccine?> FindVaccineByIdAsync(int id);
}