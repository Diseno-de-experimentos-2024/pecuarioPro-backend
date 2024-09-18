using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

namespace PecuarioProPlatform.API.VaccineManagment.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext context) : BaseRepository<Vaccine>(context), IVaccineRepository
{
    public async Task<Vaccine?> FindVaccineByCodeAsync(string code)
    {
        return await Context.Set<Vaccine>().Where(v => v.Code == code).FirstOrDefaultAsync();
    }

    public async Task<Vaccine?> FindVaccineByIdAsync(int id)
    {
        return await  Context.Set<Vaccine>().Where(v => v.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Vaccine>> FindVaccinesByUserIdAsync(UserId userId)
    {
        return await Context.Set<Vaccine>()
            .Where(v => v.UserId.Identifier == userId.Identifier)
            .ToListAsync();   }

    public async Task<IEnumerable<Vaccine>> FindVaccinesByBovineIdAsync(BovineId bovineId)
    {
        return await Context.Set<Vaccine>()
            .Where(v => v.BovineId.Identifier == bovineId.Identifier)
            .ToListAsync();
    }
}