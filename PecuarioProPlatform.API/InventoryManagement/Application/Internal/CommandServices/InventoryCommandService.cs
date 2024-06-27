using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.InventoryManagement.Application.Internal.CommandServices;

public class InventoryCommandService(IInvetoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var veterinarian = new Inventory(command);
        try
        {
            await inventoryRepository.AddAsync(veterinarian);
            await unitOfWork.CompleteAsync();
            return veterinarian;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating a Inventory:{e.Message}");
            return null;
        }
    }
    public async Task<Inventory?> Handle(DeleteInventoryCommand command)
    {
        var veterinarian = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (veterinarian == null)
        {
            return null;
        }
        inventoryRepository.Remove(veterinarian);

        try
        {
            await unitOfWork.CompleteAsync();
            return veterinarian;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting Inventory: {e.Message}");
            throw new Exception("Error deleting Inventory, e");
        }
    }
}