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
:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVaccine(CreateVaccineResource resource)
    {
        var createVaccineCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        if (vaccine is null) return BadRequest();
        var vaccineResource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return CreatedAtAction(nameof(GetVaccineByIdQuery), new { id = vaccineResource.Id }, vaccineResource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVaccineByIdQuery(int vaccineId)
    {
        var getVaccineByIdQuery = new GetVaccineByIdQuery(vaccineId);
        var vaccine = await vaccineQueryService.Handle(getVaccineByIdQuery);
        if (vaccine is null) return NotFound();
        var vaccineResource = VaccineResourceFromEntityAssembler.ToResourceFromEntity(vaccine);
        return Ok(vaccineResource);
    }
        
    
}