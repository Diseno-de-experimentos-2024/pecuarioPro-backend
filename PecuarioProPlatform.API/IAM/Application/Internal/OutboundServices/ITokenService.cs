using PecuarioProPlatform.API.IAM.Domain.Model.Aggregates;

namespace PecuarioProPlatform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}