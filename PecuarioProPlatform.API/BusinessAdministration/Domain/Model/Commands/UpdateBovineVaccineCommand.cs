namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public record UpdateBovineVaccineCommand(int BovineId, StaffId NewStaffId);