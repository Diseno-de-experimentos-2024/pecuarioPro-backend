using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface IBreedQueryService
{
    Task<Breed?> Handle(GetBreedByIdQuery query);
    Task<IEnumerable<Breed>> Handle(GetAllBreedsQuery query);

    Task<Breed?> Handle(GetBreedByNameQuery query);
}