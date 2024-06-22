using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST;





[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BreedController(IBreedCommandService breedCommandService, IBreedQueryService breedQueryService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBreeds()
    {
        var getAllBreedsQuery = new GetAllBreedsQuery();
        var breeds = await breedQueryService.Handle(getAllBreedsQuery);
        var resources = breeds.Select(BreedResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{breedId:int}")]
    public async Task<IActionResult> GetBreedById([FromRoute] int breedId)
    {
        var breed = await breedQueryService.Handle(new GetBreedByIdQuery(breedId));
        if (breed == null) return NotFound();
        var resource = BreedResourceFromEntityAssembler.ToResourceFromEntity(breed);
        return Ok(resource);

    }
    
    
}