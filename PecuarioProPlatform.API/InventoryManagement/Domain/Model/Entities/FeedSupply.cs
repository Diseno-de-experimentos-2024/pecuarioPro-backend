using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

public class FeedSupply
{
    public int Id { get; }
    
    public String Name { get; private set; }
    
    public double UnitPrice { get; private set; }
    
    public double Quantity { get; private set; }
    
    public double TotalPrice { get; private set; }
    
    public DateOnly PurchaseDate { get; private set; }

    public string Supplier { get; private set; }
    
    public string UnitOfMeasurement { get; private set; }
    
    public EStatus Status { get;  set; }

    public FeedSupply(string name, double unitPrice, double quantity, DateOnly purchaseDate, string supplier, string unitOfMeasurement, EStatus status)
    {
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
        TotalPrice = CalculateTotalPrice(unitPrice, quantity);
        PurchaseDate = purchaseDate;
        Supplier = supplier;
        UnitOfMeasurement = unitOfMeasurement;
        Status = status; 
    }

    public FeedSupply(CreateFeedSupplyCommand command)
    {
        Name = command.Name;
        UnitPrice = command.UnitPrice;
        Quantity = command.Quantity;
        TotalPrice = command.UnitPrice * command.Quantity;
        PurchaseDate = command.PurchaseDate;
        Supplier = command.Supplier;
        UnitOfMeasurement = command.UnitOfMeasurement;
        Status = Enum.TryParse<EStatus>(command.Status, out var status) ? status : EStatus.Available;    }

    
    private double CalculateTotalPrice(double unitPrice, double quantity)
    {
        return unitPrice * quantity;
    }
    public void UpdateQuantity(double newQuantity)
    {
        Quantity = newQuantity;
        TotalPrice = CalculateTotalPrice(UnitPrice, newQuantity);
    }
    public void UpdateUnitPrice(double newUnitPrice)
    {
        UnitPrice = newUnitPrice;
        TotalPrice = CalculateTotalPrice(newUnitPrice, Quantity);
    }
    public void UpdateStatus(EStatus newStatus)
    {
        Status = newStatus;
    }
    
    public void ToggleStatus()
    {
        Status = (Status == EStatus.Available) ? EStatus.OutOfStock : EStatus.Available;
    }
    
    
}