using PecuarioProPlatform.API.IAM.Domain.Model.Aggregates;
using PecuarioProPlatform.API.IAM.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    } 
}