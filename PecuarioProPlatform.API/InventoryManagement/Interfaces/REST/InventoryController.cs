using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.FeedSupplyQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.MedicineQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.ToolQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class InventoryController(IInventoryCommandService inventoryCommandService, IInventoryQueryService inventoryQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource createInventoryResource)
    {
        var createInventoryCommand =
            CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(createInventoryResource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        if (inventory is null) return BadRequest();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return CreatedAtAction(nameof(GetInventoryById), new { inventoryId = resource.Id }, resource);
    }

    [HttpGet("{inventoryId:int}")]
    public async Task<IActionResult> GetInventoryById([FromRoute] int inventoryId)
    {
        var inventory = await inventoryQueryService.Handle(new GetInventoryByIdQuery(inventoryId));
        if (inventory is null) return NotFound();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(resource);
    }

    [HttpGet("users/{userId:int}")]
    public async Task<IActionResult> GetInventoriesByUserId([FromRoute] int userId)
    {
        var inventories = await inventoryQueryService.Handle(new GetAllInventoriesByUserIdQuery(userId));
        var resources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost("{inventoryId:int}/feed-supplies")]
    public async Task<IActionResult> AddFeedSupplies([FromRoute] int inventoryId,
        [FromBody] AddFeedSupplyToInventoryResource resource)
    {
        var addFeedSupplyCommand = AddFeedSupplyToInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var feedSupply = await inventoryCommandService.Handle(addFeedSupplyCommand);
        if (feedSupply is null) return BadRequest();
        var feedResource = FeedSupplyResourceFromEntityAssembler.ToResourceFromEntity(feedSupply);
        return Ok(feedResource);
    }

    [HttpPost("{inventoryId:int}/tools")]
    public async Task<IActionResult> AddToolsToInventory([FromRoute] int inventoryId,
        [FromBody] AddToolToInventoryResource addToolToInventoryResource)
    {
        var addToolToInventoryCommand =
            AddToolToInventoryCommandFromResourceAssembler.ToCommandFromResource(addToolToInventoryResource);
        var tool = await inventoryCommandService.Handle(addToolToInventoryCommand);
        if (tool is null) return BadRequest();
        var resource = ToolResourceFromEntityAssembler.ToResourceFromEntity(tool);
        return Ok(resource);
    }

    [HttpPost("{inventoryId:int}/medicines")]
    public async Task<IActionResult> AddMedicineToInventory([FromRoute] int inventoryId,
        [FromBody] AddMedicineToInventoryResource addMedicineToInventoryResource)
    {
        var addMedicineToInventoryCommand =
            AddMedicineToInventoryCommandFromResourceAssembler.ToCommandFromResource(addMedicineToInventoryResource);
        var medicine = await inventoryCommandService.Handle(addMedicineToInventoryCommand);
        if (medicine is null) return BadRequest();
        var resource = MedicineResourceFromEntityAssembler.ToResourceFromEntity(medicine);
        return Ok(resource);

    }

    [HttpGet("{inventoryId:int}/tools")]
    public async Task<IActionResult> GetAllToolsByInventoryId([FromRoute] int inventoryId)
    {
        var getAllToolsByInventoryIdQuery = new GetAllToolsByInvetoryIdQuery(inventoryId);
        var tools = await inventoryQueryService.Handle(getAllToolsByInventoryIdQuery);
        var resources = tools.Select(ToolResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{inventoryId:int}/medicines")]
    public async Task<IActionResult> GetAllMedicinesByInventoryId([FromRoute] int inventoryId)
    {
        var medicines = await inventoryQueryService.Handle(new GetAllMedicinesByInventoryIdQuery(inventoryId));
        var resources = medicines.Select(MedicineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{inventoryId:int}/feed-supplies")]
    public async Task<IActionResult> GetAllFeedSuppliesByInventoryId([FromRoute] int inventoryId)
    {
        var feedSupplies = await inventoryQueryService.Handle(new GetAllFeedSupplyByInventoryIdQuery(inventoryId));
        var resources = feedSupplies.Select(FeedSupplyResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}