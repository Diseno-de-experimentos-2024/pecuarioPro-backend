using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Batch
{
    public EBatchStatus Status { get; protected set; }
    public Batch()
    {
        Status = EBatchStatus.Empty;
    }

    public void UpdateStatus(EBatchStatus status)
    {
        Status = status;
    }

    public void UpdateStatus(string status)
    {
        switch (status)
        {
            case "Empty":
                Status = EBatchStatus.Empty;
                break;
            case "Busy":
                Status = EBatchStatus.Busy;
                break;
            case "Full":
                Status = EBatchStatus.Full;
                break;
            default:
                throw new ArgumentException("Estado no válido", nameof(status));
        }
    }
    
}