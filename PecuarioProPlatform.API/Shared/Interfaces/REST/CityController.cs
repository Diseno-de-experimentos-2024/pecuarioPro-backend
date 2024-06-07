using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.Shared.Domain.Model.Queries;
using PecuarioProPlatform.API.Shared.Domain.Services;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CityController(ICityCommandService cityCommandService,ICityQueryService cityQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityResource createCityResource)
    {
        var createCityCommand = CreateCityCommandFromResourceAssembler.ToCommandFromResource(createCityResource);
        var city = await cityCommandService.Handle(createCityCommand);
        if (city is null) return BadRequest();
        var resource = CityResourceFromEntityAssembler.ToResourceFromEntity(city);
        return CreatedAtAction(nameof(GetCityById), new { cityId = resource.Id }, resource);
    }

    [HttpGet("{cityId:int}")]
    public async Task<IActionResult> GetCityById([FromRoute] int cityId)
    {
        var city = await cityQueryService.Handle(new GetCityByIdQuery(cityId));
        if (city is null) return NotFound();
        var resource = CityResourceFromEntityAssembler.ToResourceFromEntity(city);
        return Ok(resource);
    }
}