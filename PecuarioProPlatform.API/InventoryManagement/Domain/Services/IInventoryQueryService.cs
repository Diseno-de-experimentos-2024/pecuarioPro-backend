using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.FeedSupplyQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.MedicineQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.ToolQueries;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query);
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesByUserIdQuery query);

    Task<IEnumerable<FeedSupply>> Handle(GetAllFeedSupplyByInventoryIdQuery query);

    Task<IEnumerable<Medicine>> Handle(GetAllMedicinesByInventoryIdQuery query);
    
    Task<IEnumerable<Tool>> Handle(GetAllToolsByInvetoryIdQuery query);

    Task<Tool?> Handle(GetToolByIdQuery query);

    Task<Medicine?> Handle(GetMedicineByIdQuery query);

    Task<FeedSupply?> Handle(GetFeedSupplyByIdQuery query);

    Task<Inventory?> Handle(GetInventoryByIdQuery query);

}