namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateVaccineDateOrderCommand(Guid Id, DateTime NewDate);