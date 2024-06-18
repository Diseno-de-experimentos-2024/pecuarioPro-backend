using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform;
using PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform.Transform;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Transform;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VeterinarianController(IVeterinarianCommandService veterinarianCommandService, IVeterinarianQueryService veterinarianQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVeterinarian(CreateVeterinarianResource createVeterinarianResource)
    {
        var createVeterinarianCommand =
            CreateVeterinarianCommandFromResourceAssembler.ToCommandFromResource(createVeterinarianResource);
        var veterinarian = await veterinarianCommandService.Handle(createVeterinarianCommand);
        var resource = VeterinarianResourceFromEntityAssembler.ToResourceFromEntity(veterinarian);
        return CreatedAtAction(nameof(GetVeterinariansByIdQuery), new { veterinarianid = resource.Id }, resource);
    }
    [HttpGet("{veterinarianid}")]
    public async Task<IActionResult> GetVeterinariansByIdQuery(int veterinarianid)
    {
        var getVeterinarianByIdQuery = new GetVeterinariansByIdQuery(veterinarianid);
        var veterinarian = await veterinarianQueryService.Handle(getVeterinarianByIdQuery);
        if (veterinarian is null) return NotFound();
        var veterinarianResource = VeterinarianResourceFromEntityAssembler.ToResourceFromEntity(veterinarian);
        return Ok(veterinarianResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetVeterinarianQuery()
    {
        var getVeterinarianQuery = new GetAllVeterinariansQuery();
        var veterinarians = await veterinarianQueryService.Handle(getVeterinarianQuery);
        var veterinarianResources = veterinarians.Select(VeterinarianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(veterinarianResources);
    }
}