using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;

public partial class Inventory
{
    
    public Inventory() { }

    
    public int Id { get; }
    public string ProductName { get; private set; }
    public string Quantity { get; private set; }
    public string PhotoUrl { get; private set; }


    public Inventory(string productname, string quantity, string photoUrl)
    {
        ProductName = productname;
        Quantity = quantity;
        PhotoUrl = photoUrl;
    }
    
    public Inventory(CreateInventoryCommand command) : this(
        command.ProductName,
        command.Quantity,
        command.PhotoUrl)
    {}
    
}



