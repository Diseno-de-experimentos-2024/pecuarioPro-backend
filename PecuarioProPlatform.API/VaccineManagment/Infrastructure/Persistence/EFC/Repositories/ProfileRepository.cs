using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects;
using PecuarioProPlatform.API.VaccineManagment.Domain.Repositories;

namespace PecuarioProPlatform.API.VaccineManagment.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Vaccine>(context), IVaccineRepository
{
    public Task<Vaccine?> FindVaccineByCodeAsync(VaccineCode code)
    {
        return Context.Set<Vaccine>().Where(v => v.Code == code).FirstOrDefaultAsync();
    }
}