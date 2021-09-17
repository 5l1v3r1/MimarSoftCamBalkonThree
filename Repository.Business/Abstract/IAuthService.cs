using Core.Utilities.Results;
using Repository.Business.Utilities.Security.JWT;
using Repository.Entities.Auth;
using Repository.Entities.ComplexTypes;

namespace Repository.Business.Abstract
{
    public interface IAuthService/* : IServiceRepository<AspNetUserAspNetUser>*/
    {
        IDataResult<AspNetUser> Register(UserForRegister userForRegister, string password);

        //IDataResult<AspNetUser> Login(UserForLogin userForLogin);

        //IResult UserExists(string email);
        //IResult AddRole(AspNetRole role);

        IDataResult<AccessToken> CreateAccessToken(AspNetUser user);
    }
}