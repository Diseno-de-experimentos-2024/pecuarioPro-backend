using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

public class DistrictRepository(AppDbContext context): BaseRepository<District>(context), IDistrictRepository
{
    public  async Task<District?> FindDistrictByNameAsync(string districtName)
    {
        var district = await Context.Set<District>().FirstOrDefaultAsync(d => d.Name == districtName);
        return district;
        
    }
    
    
}
