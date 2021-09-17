using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository.Entities.Auth;
using System.Threading.Tasks;

namespace UI.WebMvcCore.Areas.Identity.Pages.Account.Manage
{
    public class ResetAuthenticatorModel : PageModel
    {
        private UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        private ILogger<ResetAuthenticatorModel> _logger;

        public ResetAuthenticatorModel(
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager,
            ILogger<ResetAuthenticatorModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"'{_userManager.GetUserId(User)}' kimliğine sahip kullanıcı yüklenemiyor.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"'{_userManager.GetUserId(User)}' kimliğine sahip kullanıcı yüklenemiyor.");
            }

            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            _logger.LogInformation("'{UserId}' kimliğine sahip kullanıcı, kimlik doğrulama uygulaması anahtarını sıfırladı.", user.Id);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Kimlik doğrulayıcı uygulama anahtarınız sıfırlandı, kimlik doğrulayıcı uygulamanızı yeni anahtarı kullanarak yapılandırmanız gerekecek.";

            return RedirectToPage("./EnableAuthenticator");
        }
    }
}