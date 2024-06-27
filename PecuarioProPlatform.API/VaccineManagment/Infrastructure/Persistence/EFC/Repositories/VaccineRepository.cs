using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

namespace PecuarioProPlatform.API.VaccineManagment.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext context) : BaseRepository<Vaccine>(context), IVaccineRepository
{
    public Task<Vaccine?> FindVaccineByCodeAsync(string code)
    {
        return Context.Set<Vaccine>().Where(v => v.Code == code).FirstOrDefaultAsync();
    }

    public Task<Vaccine?> FindVaccineByIdAsync(int id)
    {
        return Context.Set<Vaccine>().Where(v => v.Id == id).FirstOrDefaultAsync();
    }
}