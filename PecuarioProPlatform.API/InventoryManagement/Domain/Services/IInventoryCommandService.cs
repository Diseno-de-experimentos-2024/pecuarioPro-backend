using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryCommandService
{
    Task<FeedSupply?> Handle(CreateFeedSupplyCommand command);
    Task<Tool?> Handle(CreateToolCommand command);
    Task<Medicine?> Handle(CreateMedicineCommand command);

    Task<Inventory?> Handle(CreateInventoryCommand command);

    Task<Medicine?> Handle(UpdateStatusMedicineCommand command);

    Task<FeedSupply> Handle(UpdateStatusFeedSupplyCommand command);

    Task<Tool?> Handle(UpdateStatusToolCommand command);

    Task<Tool?> Handle(UpdateToolConditionCommand command);
}