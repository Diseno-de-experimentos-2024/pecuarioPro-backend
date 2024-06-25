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
public class DepartmentsController(IDepartmentCommandService departmentCommandService, IDepartmentQueryService departmentQueryService) : ControllerBase
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
    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        var getAllDepartmentsQuery = new GetAllDepartmentsQuery();
        var departments = await departmentQueryService.Handle(getAllDepartmentsQuery);
        var resources = departments.Select(DepartmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{departmentId:int}")]
    public async Task<IActionResult> GetDepartmentById([FromRoute] int departmentId)
    {
        var department = await departmentQueryService.Handle(new GetDepartmentByIdQuery(departmentId));
        if (department is null) return NotFound();
        var resource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return Ok(resource);
    }
    
    [HttpGet("name/{departmentName}")]
    public async Task<IActionResult> GetCityByName([FromRoute] string departmentName)
    {
        var department = await departmentQueryService.Handle(new GetDepartmentByNameQuery(departmentName));
        if (department is null) return NotFound();
        var resource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return Ok(resource);
    }
    
    
}