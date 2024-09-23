using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;

public class Inventory
{
    public int Id { get;  }
    public UserId UserId { get; private set; }
    
    public ICollection<Tool> Tools { get; }
    
    public ICollection<FeedSupply> FeedSupplies { get; }
    
    public ICollection<Medicine> Medicines { get; }
    
    

    public Inventory()
    {
        Tools = new List<Tool>();
        FeedSupplies = new List<FeedSupply>();
        Medicines = new List<Medicine>();
    }

    public Inventory(CreateInventoryCommand command):this()
    {
        UserId = new UserId(command.UserId);
    }

    public void AddMedicine(Medicine medicine)
    {
        Medicines.Add(medicine);
    }

    public void AddTool(Tool tool)
    {
        Tools.Add(tool);
    }

    public void AddFeedSupply(FeedSupply feedSupply)
    {
        FeedSupplies.Add(feedSupply);
    }
    
    
}