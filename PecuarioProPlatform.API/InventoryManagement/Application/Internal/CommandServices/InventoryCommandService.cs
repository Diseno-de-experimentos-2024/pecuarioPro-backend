using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.InventoryManagement.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    public async Task<FeedSupply?> Handle(CreateFeedSupplyCommand command)
    {
        var feedSupply = new FeedSupply(command);
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");
        inventory.AddFeedSupply(feedSupply);
        try
        {
            await unitOfWork.CompleteAsync();
            return feedSupply;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a feed supply:{e.Message} ");
            return null;
        }
    }

    public async Task<Tool?> Handle(CreateToolCommand command)
    {
        var tool = new Tool(command);
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");
        inventory.AddTool(tool);

        try
        {
            await unitOfWork.CompleteAsync();
            return tool;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a tool:{e.Message} ");
            return null;
        }
    }

    public async Task<Medicine?> Handle(CreateMedicineCommand command)
    {
        var medicine = new Medicine(command);
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");
        inventory.AddMedicine(medicine);
        try
        {
            await unitOfWork.CompleteAsync();
            return medicine;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a medicine:{e.Message} ");
            return null;
        }
    }

    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var inventory = new Inventory(command);
        try
        {
            await inventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"An error occurred while creating a inventory:{e.Message} ");
            return null;
        }
    }

    public async Task<Medicine?> Handle(UpdateStatusMedicineCommand command)
    {
        var medicine = await inventoryRepository.FindMedicineByIdAndInventoryIdAsync(command.MedicineId,command.InventoryId);
        if (medicine is null) throw new Exception("Medicine not found");

        medicine.ToggleStatus(); 

        try
        {
            await unitOfWork.CompleteAsync();
            return medicine;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the status of the medicine: {e.Message}");
            return null;
        }
    }

    public async Task<FeedSupply> Handle(UpdateStatusFeedSupplyCommand command)
    {
        var feedSupply = await inventoryRepository.FindFeedSupplyByIdAndInventoryIdAsync(command.FeedSupplyId, command.InventoryId);
        if (feedSupply is null) throw new Exception("Feed supply not found");

        feedSupply.ToggleStatus();

        try
        {
            await unitOfWork.CompleteAsync();
            return feedSupply;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the status of the feed supply: {e.Message}");
            return null;
        }
    }

    public async Task<Tool?> Handle(UpdateStatusToolCommand command)
    {
        var tool = await inventoryRepository.FindToolByIdAndInventoryIdAsync(command.ToolId, command.InventoryId);
        if (tool is null) throw new Exception("Tool not found");

        tool.ToggleStatus();

        try
        {
            await unitOfWork.CompleteAsync();
            return tool;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the status of the tool: {e.Message}");
            return null;
        }
    }

    public async Task<Tool?> Handle(UpdateToolConditionCommand command)
    {
        var tool = await inventoryRepository.FindToolByIdAndInventoryIdAsync(command.ToolId, command.InventoryId);
        if (tool is null) throw new Exception("Tool not found");

        tool.UpdateCondition(Enum.Parse<EToolCondition>(command.Condition, true));

        try
        {
            await unitOfWork.CompleteAsync();
            return tool;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the status of the tool: {e.Message}");
            return null;
        }
    }
}