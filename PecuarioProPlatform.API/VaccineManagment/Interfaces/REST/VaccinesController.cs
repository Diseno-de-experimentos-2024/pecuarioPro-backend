using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.VaccineManagment.Domain.Services;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VaccinesController(IVaccineCommandService vaccineCommandService, IVaccineQueryService vaccineQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVaccine(CreateVaccineResource createVaccineResource)
    {
        var createVaccineCommand = CreateVaccinesCommandFromResourceAssembler.ToCommandFromResource(createVaccineResource);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        if (vaccine is null) return BadRequest();
        var resource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return CreatedAtAction(nameof(GetVaccineByIdQuery), new { vaccineid = resource.Id }, resource);
    }
    
    [HttpGet("{vaccineid}")]
    public async Task<IActionResult> GetVaccineByIdQuery(int vaccineid)
    {
        var getVaccineByIdQuery = new GetVaccineByIdQuery(vaccineid);
        var vaccine = await vaccineQueryService.Handle(getVaccineByIdQuery);
        if (vaccine is null) return NotFound();
        var vaccineResource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return Ok(vaccineResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetVaccinesQuery()
    {
        var getVaccinesQuery = new GetAllVaccinesQuery();
        var vaccines = await vaccineQueryService.Handle(getVaccinesQuery);
        var vaccineResources = vaccines.Select(VaccineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vaccineResources);
    }
    
    
    
}