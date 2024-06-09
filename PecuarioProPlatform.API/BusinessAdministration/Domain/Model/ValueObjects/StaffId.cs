namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

// public class StaffId
// {
//     public Guid Value { get; private set; }
//
//     public StaffId(Guid value)
//     {
//         Value = value;
//     }
// }

public record StaffId(Guid Identifier)
{
    public StaffId(): this(Guid.NewGuid()){}
}