using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;
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

    [HttpGet]
    public async Task<IActionResult> GetAllBovines()
    {
        var getAllBovinesQuery = new GetAllBovinesQuery();
        var bovines = await bovineQueryService.Handle(getAllBovinesQuery);
        var resources = bovines.Select(BovineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("batches/{batchId:int}/bovines")]
    public async Task<IActionResult> GetAllBovinesByBatchId([FromRoute]int batchId)
    {
        var getAllBovinesByBatchIdQuery =  new GetAllBovinesByBatchIdQuery(batchId);
        var bovines = await bovineQueryService.Handle(getAllBovinesByBatchIdQuery);
        var resources = bovines.Select(BovineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("users/{userId:int}")]
    public async Task<IActionResult> GetAllBovinesByUserId([FromRoute] int userId)
    {
        var bovines = await bovineQueryService.Handle(new GetAllBovinesByUserIdQuery(userId));
        var resources = bovines.Select(BovineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
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

    [HttpPut("{bovineId:int}")]
    public async Task<IActionResult> UpdateBovine([FromRoute] int bovineId,
        [FromBody] CreateBovineResource createBovineResource)
    {
        var updateBovineCommand =
            UpdateBovineCommandFromResourceAssemble.ToCommandFromResource(bovineId, createBovineResource);
        var bovine = await bovineCommandService.Handle(updateBovineCommand);
        if (bovine == null) return NotFound();
        var resource = BovineResourceFromEntityAssembler.ToResourceFromEntity(bovine);
        return Ok(resource);
    }
    
    [HttpPut("{bovineId:int}/modify-weight-bovine")]
    public async Task<IActionResult> ModifyWeightBovine([FromRoute] int bovineId, [FromBody] ModifyWeightBovineResource modifyWeightBovineResource)
    {
        var modifyWeightBovineCommand = ModifyWeightBovineFromResourceAssembler.ToCommandFromResource(modifyWeightBovineResource, bovineId);
        var bovine = await bovineCommandService.Handle(modifyWeightBovineCommand);
        if (bovine is null) return BadRequest();
        var resource = BovineResourceFromEntityAssembler.ToResourceFromEntity(bovine);
        return CreatedAtAction(nameof(GetBovineById), new { bovineId = resource.Id }, resource);
    }

    [HttpPost("{bovineId:int}/add-weight-record")]
    public async Task<IActionResult> AddWeightRecord([FromRoute] int bovineId, [FromBody] AddNewWeightRecordResource addNewWeightRecordResource)
    {
        var addNewWeightRecordCommand = AddWeightRecordToBovineCommandFromResourceAssembler.ToCommandFromResource(bovineId, addNewWeightRecordResource);
        var bovine = await bovineCommandService.Handle(addNewWeightRecordCommand);
        if (bovine is null) return BadRequest();
    
        var weightRecords = await bovineQueryService.Handle(new GetAllWeightRecordsByBovineIdQuery(bovineId));
        var resourceList = weightRecords.Select(WeightRecordResourceFromEntityAssembler.ToResourceFromEntity).ToList();

        return Ok(resourceList);
    }
    
    [HttpPost("{bovineId:int}/add-images")]
    public async Task<IActionResult> AddImageAssetToBovine([FromRoute] int bovineId, [FromBody] AddImageAssetToBovineResource addImageAssetToBovineResource)
    {
        var addImageToBovineCommand =
            AddImageToBovineCommandFromResourceAssembler.ToCommandFromResource(addImageAssetToBovineResource,bovineId);
        var bovine = await  bovineCommandService.Handle(addImageToBovineCommand);
        if (bovine is null) return BadRequest();
        var resource = BovineResourceFromEntityAssembler.ToResourceFromEntity(bovine);
        return CreatedAtAction(nameof(GetBovineById), new { bovineId = resource.Id }, resource);
    }
    
    
    [HttpGet("{bovineId:int}/weight-records")]
    public async Task<IActionResult> GetAllWeightRecordsByBovineId([FromRoute] int bovineId)
    {
        var weightRecords = await bovineQueryService.Handle(new GetAllWeightRecordsByBovineIdQuery(bovineId));
        if (weightRecords is null) return NotFound();

        var resourceList = new List<WeightRecordResource>();
        foreach (var weightRecord in weightRecords)
        {
            var resource = WeightRecordResourceFromEntityAssembler.ToResourceFromEntity(weightRecord);
            resourceList.Add(resource);
        }

        return Ok(resourceList);
    }

    [HttpDelete("{bovineId:int}")]
    public async Task<IActionResult> DeleteBovine([FromRoute] int bovineId)
    {
       var bovine = await bovineCommandService.Handle(new DeleteBovineCommand(bovineId));
       if (bovine is null)return BadRequest();
        return Ok();
    }
   
    
}