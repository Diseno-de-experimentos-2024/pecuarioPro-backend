using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record InventoryResource(int Id, int UserId, ICollection<ToolResource> Tools,ICollection<FeedSupplyResource> FeedSupplies
    , ICollection<MedicineResource> Medicines);