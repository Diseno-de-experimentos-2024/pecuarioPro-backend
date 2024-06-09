using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

public interface IVaccineRepository : IBaseRepository<Vaccines>
{
    Task<Vaccines?> FindByCodeAsync(string code);
    Task<Vaccines?> FindByNameAsync(string name);
    Task<Vaccines?> FindByNameAndCodeAsync(string name, string code);
    new Task<Vaccines?> FindByIdAsync(int id);
}