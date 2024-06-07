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
public class DepartmentController(IDepartmentCommandService departmentCommandService, IDepartmentQueryService departmentQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentResource createDepartmentResource)
    {
        var createDepartmentCommand = CreateDepartmentCommandFromResourceAssembler.ToCommandFromResource(createDepartmentResource);
        var department = await departmentCommandService.Handle(createDepartmentCommand);
        if (department is null) return BadRequest();
        var resource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = resource.Id }, resource);
    }

    [HttpGet("{departmentId:int}")]
    public async Task<IActionResult> GetDepartmentById([FromRoute] int departmentId)
    {
        var department = await departmentQueryService.Handle(new GetDepartmentByIdQuery(departmentId));
        if (department is null) return NotFound();
        var resource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return Ok(resource);
    }
}