using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Repositories;


namespace PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;

public interface IInvetoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory?> FindByProductName(string productname);
    new Task<Inventory?> FindByIdAsync(int id);
}