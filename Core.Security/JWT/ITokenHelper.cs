using Core.Security.Entities;
using Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaims> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}
