using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IBreedCommandService
{
    Task<Breed?> Handle(CreateBreedCommand command);
}