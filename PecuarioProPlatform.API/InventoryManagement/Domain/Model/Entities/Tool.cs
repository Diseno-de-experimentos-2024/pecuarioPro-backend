using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

public class Tool
{
    public int Id { get; private set; }
    
    public string Name { get; private set; }
    
    public double UnitPrice { get; private set; }
    
    public double Quantity { get; private set; }
    
    public double TotalPrice { get; private set; }
    
    public DateOnly PurchaseDate { get; private set; }
    
    public string Supplier { get; private set; }
    
    public EStatus Status { get; private set; }
    
    public EToolCondition Condition { get; private set; }

    public Tool(string name, double unitPrice, double quantity, DateOnly purchaseDate, string supplier, EStatus status,EToolCondition condition)
    {
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
        TotalPrice = CalculateTotalPrice(unitPrice, quantity);
        PurchaseDate = purchaseDate;
        Supplier = supplier;
        Status = status;
        Condition = condition;
    }

    public Tool(CreateToolCommand command) : this(command.Name, command.UnitPrice,
        command.Quantity, command.PurchaseDate, command.Supplier, command.Status, command.Condition){}

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