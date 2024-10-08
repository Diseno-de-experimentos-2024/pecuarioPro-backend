using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;

public class Medicine
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateOnly ExpirationDate { get; private set; }
    public string Supplier { get; private set; }
    public double Volume { get; private set; }
    public EStatus Status { get;  set; }
    

    public Medicine(string name, DateOnly expirationDate, string supplier, double volume, EStatus status)
    {
        Name = name;
        ExpirationDate = expirationDate;
        Supplier = supplier;
        Volume = volume;
        Status = status;
    }
    public Medicine(CreateMedicineCommand command):this(command.Name,command.ExpirationDate,
        command.Supplier,command.Volume,command.Status){}
    
    
    public void UpdateStatus(EStatus newStatus)
    {
        Status = newStatus;
    }
    
    public void ToggleStatus()
    {
        Status = (Status == EStatus.Available) ? EStatus.OutOfStock : EStatus.Available;
    }
    
    
}