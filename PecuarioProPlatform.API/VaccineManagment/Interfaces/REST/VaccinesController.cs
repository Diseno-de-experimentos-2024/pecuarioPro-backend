using System.Net.Mime;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VaccinesController(IVaccineCommandService vaccineCommandService, IVaccineQueryService vaccineQueryService)
:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVaccine(CreateVaccineResource resource)
    {
        
        var createVaccineCommand = CreateVaccineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        if (vaccine is null) return BadRequest();
        var vaccineResource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return CreatedAtAction(nameof(GetVaccineById), new { id = vaccineResource.Id }, vaccineResource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVaccineById([FromRoute]int vaccineId)
    {
        var getVaccineByIdQuery = new GetVaccineByIdQuery(vaccineId);
        var vaccine = await vaccineQueryService.Handle(getVaccineByIdQuery);
        if (vaccine is null) return NotFound();
        return Ok(vaccine);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllVaccines()
    {
        var getAllVaccinesQuery = new GetAllVaccineQuery();
        var vaccines = await vaccineQueryService.Handle(getAllVaccinesQuery);
        return Ok(vaccines);
    }

    [HttpGet("users/{userId:int}")]
    public async Task<IActionResult> GetAllVaccinesByUserId([FromRoute]int userId)
    {
        var getAllVaccinesByUserIdQuery = new GetAllVaccineByUserIdQuery(userId);
        var vaccines = await vaccineQueryService.Handle(getAllVaccinesByUserIdQuery);
        var resources = vaccines.Select(VaccineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("bovines/{bovineId:int}")]
    public async Task<IActionResult> GetAllVaccinesByBovineId([FromRoute] int bovineId)
    {
        var getAllVaccinesByBovineIdQuery = new GetAllVaccineByBovineIdQuery(bovineId);
        var vaccines = await vaccineQueryService.Handle(getAllVaccinesByBovineIdQuery);
        var resources = vaccines.Select(VaccineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
 
    }
    
    
    
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVaccine([FromRoute] int id, [FromBody] CreateVaccineResource createVaccineResource)
    {
        var updateVaccineCommand = UpdateVaccineCommandFromResourceAssembler.ToCommandFromResource(id, createVaccineResource);
        var vaccine = await vaccineCommandService.Handle(updateVaccineCommand);
        if (vaccine == null) return NotFound();
        var resource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return Ok(resource);
    }
        
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteVaccine([FromRoute] int id)
    {
        var vaccine = await vaccineCommandService.Handle(new DeleteVaccineCommand(id));
        if (vaccine is null) return NotFound();
        return Ok();
    }
    
    
    
}