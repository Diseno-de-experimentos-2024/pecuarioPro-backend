using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST;



[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BovinesController(IBovineCommandService bovineCommandService,
    IBovineQueryService bovineQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBovine([FromBody] CreateBovineResource createBovineResource)
    {
        var createBovineCommand = CreateBovineCommandFromResourceAssembler.ToCommandFromResource(createBovineResource);
        var bovine = await bovineCommandService.Handle(createBovineCommand);
        if (bovine is null) return BadRequest();
        var resource = BovineResourceFromEntityAssembler.ToResourceFromEntity(bovine);
        return CreatedAtAction(nameof(GetBovineById), new { bovineId = resource.Id }, resource);
    }
    
    
    [HttpGet("{bovineId:int}")]
    public async Task<IActionResult> GetBovineById([FromRoute] int bovineId)
    {
        var bovine = await bovineQueryService.Handle(new GetBovineByIdQuery(bovineId));
        Console.WriteLine(bovine);
        if (bovine == null) return NotFound();
        var resource = BovineResourceFromEntityAssembler.ToResourceFromEntity(bovine);
        Console.WriteLine(resource);
        return Ok(resource);
    }
    
    
    
}