using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST;




[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CampaignsController(ICampaignCommandService campaignCommandService, ICampaignQueryService campaignQueryService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignResource createCampaignResource)
    {
        var createCampaignCommand =
            CreateCampaignCommandFromResourceAssembler.ToCommandFromResource(createCampaignResource);
        var campaign = await campaignCommandService.Handle(createCampaignCommand);
        if (campaign is null) return BadRequest();
        var resource = CampaignResourceFromEntityAssembler.ToResourceFromEntity(campaign);
        return CreatedAtAction(nameof(GetCampaignById), new { campaignId = resource.Id }, resource);
    }


    [HttpGet("{campaignId:int}")]
    public async Task<IActionResult> GetCampaignById([FromRoute] int campaignId)
    {
        var campaign = await campaignQueryService.Handle(new GetCampaignByIDQuery(campaignId));
        if (campaign is null) return NotFound();
        var resource = CampaignResourceFromEntityAssembler.ToResourceFromEntity(campaign);
        return Ok(resource);
    }

    [HttpPut("{campaignId:int}/modify-duration")]
    public async Task<IActionResult> ModifyCampaignDuration([FromRoute] int campaignId, [FromBody] ModifyDurationCampaignResource modifyDurationCampaignResource)
    {
        var modifyDurationCampaignCommand = ModifyDurationCampaingFromResourceAssembler.ToCommandFromResource(modifyDurationCampaignResource, campaignId);
        var campaign = await campaignCommandService.Handle(modifyDurationCampaignCommand);
        if (campaign is null) return BadRequest();
        var resource = CampaignResourceFromEntityAssembler.ToResourceFromEntity(campaign);
        return CreatedAtAction(nameof(GetCampaignById), new { campaignId = resource.Id }, resource);
    }
    
}