using PecuarioProPlatform.API.IAM.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.IAM.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}