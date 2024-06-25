using PecuarioProPlatform.API.IAM.Domain.Model.Aggregates;
using PecuarioProPlatform.API.IAM.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}