using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Batch
{
    public EBatchStatus Status { get; protected set; }
    public Batch()
    {
        Status = EBatchStatus.Empty;
    }


}