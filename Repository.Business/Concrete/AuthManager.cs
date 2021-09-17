using Core.Utilities.Results;
using Core.Utilities.Results.Implementations;
using Repository.Business.Abstract;
using Repository.Business.Utilities.Security.Hashing;
using Repository.Business.Utilities.Security.JWT;
using Repository.Entities.Auth;
using Repository.Entities.ComplexTypes;

namespace Repository.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        //private readonly RepositoryContext _repositoryContext;
        //private readonly ITokenHelper _tokenHelper;
        //DatabaseSeed databaseSeed;
        public AuthManager(/*RepositoryContext repositoryContext*//*, ITokenHelper tokenHelper*/)
        {
            //_repositoryContext = repositoryContext;
            //_tokenHelper = tokenHelper;
            //databaseSeed = new DatabaseSeed();
        }

        public IDataResult<AspNetUser> Register(UserForRegister userForRegister, string password)
        {
            HashingHelper.CreatePasswordHash(password,
                out var passwordHash,
                out var passwordSalt);

            var user = new AspNetUser()
            {
                Email = userForRegister.Email,
                UserName = userForRegister.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AccessFailedCount = 0,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                Status = true
            };

            return new SuccessDataResult<AspNetUser>(user,
                "Kayıt oldu");
        }

        //public IDataResult<AspNetUser> Login(UserForLogin userForLogin)
        //{
        //    var userToCheck = _userService
        //        .Get_ByMail(userForLogin.Email);

        //    if (userToCheck == null)
        //        return new ErrorDataResult<AspNetUser>(
        //            "Kullanıcı bulunamadı");

        //    if (!HashingHelper
        //        .VerifyPasswordHash(
        //            userForLogin.Password,
        //            userToCheck.PasswordHash,
        //            userToCheck.PasswordSalt
        //        ))
        //        return new ErrorDataResult<AspNetUser>(
        //            "Parola hatası!");

        //    return new SuccessDataResult<AspNetUser>(userToCheck,
        //        "Başarılı giriş.");
        //}

        //public IResult UserExists(string email)
        //{
        //    if (_userService.Get_ByMail(email) != null)
        //        return new ErrorResult("Kullanıcı mevcut.");

        //    return new SuccessResult();
        //}

        public IDataResult<AccessToken> CreateAccessToken(AspNetUser user)
        {
            //var claims = _userService.GetClaims(user);
            var accessToken = new AccessToken();// _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken,
                "Token oluşturuldu.");
        }

        //public IResult AddRole(AspNetRole role)
        //{
        //    //try
        //    //{
        //    //    //databaseSeed.RunSeed();
        //    //    //databaseSeed.Add(role);
        //    //    //databaseSeed.SaveChanges();
        //    //    return new Result(true);
        //    //}
        //    //catch (System.Exception)
        //    //{
        //    //    return new Result(false);
        //    //}
        //}
    }
}