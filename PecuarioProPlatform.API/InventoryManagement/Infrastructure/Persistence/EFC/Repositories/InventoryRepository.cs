using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context): BaseRepository<Inventory>(context), IInvetoryRepository
{
    public Task<Inventory?> FindBySpecialty(string specialty)
    {
        return Context.Set<Inventory>().Where(p=>p.ProductName == specialty).FirstOrDefaultAsync();
    }

    public Task<Inventory?> FindByProductName(string productname)
    {
        throw new NotImplementedException();
    }

    public new Task<Inventory?> FindByIdAsync(int id)
    {
        return Context.Set<Inventory>().Where(p=>p.Id == id).FirstOrDefaultAsync();
    }
}