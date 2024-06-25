using PecuarioProPlatform.API.IAM.Domain.Model.Commands;
using PecuarioProPlatform.API.IAM.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}