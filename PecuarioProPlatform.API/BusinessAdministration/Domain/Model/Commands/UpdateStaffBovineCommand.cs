
namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public record UpdateStaffBovineCommand(int BovineId, StaffId NewStaffId);