using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;

public class BreedRepository(AppDbContext context): BaseRepository<Breed>(context),IBreedRepository
{
    public async Task<Breed?> FindBreedByNameAsync(string breedName)
    {
        var breed = await Context.Set<Breed>().FirstOrDefaultAsync(b => b.Name == breedName);
        return breed;
    }
}