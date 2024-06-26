using System.ComponentModel.DataAnnotations.Schema;

namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;

public class StaffAudit
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}