using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

public interface IVaccineRepository : IBaseRepository<Vaccine>
{
    Task<Vaccine?> FindVaccineByCodeAsync(string code);
    Task<Vaccine?> FindVaccineByIdAsync(int id);

    Task<IEnumerable<Vaccine>> FindVaccinesByUserIdAsync(UserId userId);
    Task<IEnumerable<Vaccine>> FindVaccinesByBovineIdAsync(BovineId bovineId);

}
    