using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;


namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class InventoryController(
    IInventoryCommandService inventoryCommandService, 
    IInventoryQueryService inventoryQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInventory(CreateInventoryResource createInventoryResource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(createInventoryResource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        if (inventory is null) return BadRequest();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return CreatedAtAction(nameof(GetInventoryByIdQuery), new { inventoryid = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetInventoryQuery()
    {
        var getInventoryQuery = new GetAllInvetoryQuery();
        var veterinarians = await inventoryQueryService.Handle(getInventoryQuery);
        var inventoryResources = veterinarians.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(inventoryResources);
    }
    [HttpGet("{iventoryid}")]
    public async Task<IActionResult> GetInventoryByIdQuery(int inventoryid)
    {
        var getInventoryByIdQuery = new GetInventoryByIdQuery(inventoryid);
        var inventory = await inventoryQueryService.Handle(getInventoryByIdQuery);
        if (inventory is null) return NotFound();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }

    [HttpDelete("{inventoryid:int}")]
    public async Task<IActionResult> DeleteInventory([FromRoute] int inventoryid)
    {
        var inventory = await inventoryCommandService.Handle(new DeleteInventoryCommand(inventoryid));
        if (inventory  is null) return BadRequest();
        return Ok();
    }

    
}