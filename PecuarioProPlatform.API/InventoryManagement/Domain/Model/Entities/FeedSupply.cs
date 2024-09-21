using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

public class FeedSupply
{
    public int Id { get; }
    
    public String Name { get; private set; }
    
    public Double UnitPrice { get; private set; }
    
    public Double Quantity { get; private set; }
    
    public Double TotalPrice { get; private set; }
    
    public DateOnly PurchaseDate { get; private set; }

    public string Supplier { get; private set; }
    
    public string UnitOfMeasurement { get; private set; }
    
    public EStatus Status { get; private set; }

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
        Status = command.Status; 
    }

    
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
}