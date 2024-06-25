using PecuarioProPlatform.API.IAM.Domain.Model.Commands;
using PecuarioProPlatform.API.IAM.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}