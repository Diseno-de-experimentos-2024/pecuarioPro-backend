using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;


namespace PecuarioProPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
    
    Task<Inventory?> Handle(DeleteInventoryCommand command);
}