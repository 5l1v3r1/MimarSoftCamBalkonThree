using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Business.Abstract;
using Repository.Business.Utilities.Security.JWT;
using Repository.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.WebMvcCore.Controllers
{
    [Route("{controller}")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        //private readonly IUserService _userService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            //_userService = userService;
        }

        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new UserForLogin { ReturnUrl = returnUrl });
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLoginDto)
        {
            //var userToLogin = _authService.Login(userForLoginDto);
            //if (!userToLogin.Success)
            //{
            //    return BadRequest(userToLogin.Message);
            //}
            //var result = _authService.CreateAccessToken(userToLogin.Data);

            //if (result.Success)
            //{
            //    await CookieJwt(result.Data);

            //    if (string.IsNullOrEmpty(userForLoginDto.ReturnUrl))
            //        return RedirectToAction("index", "Home");
            //    else
            //        return Redirect(userForLoginDto.ReturnUrl);
            //}
            //return BadRequest(result.Message);
            return null;
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegisterDto)
        {
            //var userExists = _authService.UserExists(userForRegisterDto.Email);
            //if (!userExists.Success)
            //{
            //    return BadRequest(userExists.Message);
            //}
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (registerResult.Success)
            {
                //var result = _authService.CreateAccessToken(_userService.GetByMail(userForRegisterDto.Email).Data);

                //await CookieJwt(result.Data);

                return RedirectToAction("Demo", "Home");
            }

            return BadRequest(registerResult.Message);
        }

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(UserForLogin userForLoginDto)
        {
            //var userExists = _authService.UserExists(userForLoginDto.Email);
            //if (!userExists.Success)
            //{
            //    return BadRequest(userExists.Message);
            //}
            //string password = _authService.CreateAccessToken(12);
            //_authService.SendPasswordEmail(userForLoginDto.Email, password);
            return RedirectToAction("PasswordInfo");
        }

        [Route("PasswordInfo")]
        public IActionResult PasswordInfo()
        {
            return View();
        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            //_authService.LogOut();
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task CookieJwt(AccessToken result)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(result.Token);
            var claims = new List<Claim>();
            claims.AddRange(token.Claims);
            claims.Add(new Claim("token", result.Token));
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddMinutes(10),
                IssuedUtc = DateTime.Now,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}