using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;

public class BreedQueryService(IBreedRepository breedRepository): IBreedQueryService
{
    private IBreedQueryService _breedQueryServiceImplementation;
    public async Task<Breed?> Handle(GetBreedByIdQuery query)
    {
        return await breedRepository.FindByIdAsync(query.raceId);

    }

    public async Task<IEnumerable<Breed>> Handle(GetAllBreedsQuery query)
    {

        return await breedRepository.ListAsync();
    }

    public async Task<Breed?> Handle(GetBreedByNameQuery query)
    {
        return await breedRepository.FindBreedByNameAsync(query.breedName);
    }
}