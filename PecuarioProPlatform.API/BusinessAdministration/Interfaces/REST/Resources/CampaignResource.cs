using System.Runtime.InteropServices.JavaScript;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record CampaignResource(int Id,string Name, DateOnly DateStart, DateOnly DateEnd, string Condition, int Duration, string userId);