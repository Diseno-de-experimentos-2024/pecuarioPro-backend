using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

namespace PecuarioProPlatform.API.VaccineManagment.Infrastructure.Persistence.EFC.Repositories;

public class VaccinesRepository(AppDbContext context): BaseRepository<Vaccines>(context), IVaccineRepository
{
    public Task<Vaccines?> FindByCodeAsync(string code)
    {
        return Context.Set<Vaccines>().Where(p=>p.Code == code).FirstOrDefaultAsync();
    }

    public Task<Vaccines?> FindByNameAsync(string name)
    {
        return Context.Set<Vaccines>().Where(p=>p.Name == name).FirstOrDefaultAsync();
    }

    public Task<Vaccines?> FindByNameAndCodeAsync(string name, string code)
    {
        return Context.Set<Vaccines>().Where(p=>p.Name == name && p.Code == code).FirstOrDefaultAsync();
    }
    
    public new Task<Vaccines?> FindByIdAsync(int id)
    {
        return Context.Set<Vaccines>().Where(p=>p.Id == id).FirstOrDefaultAsync();
    }
}