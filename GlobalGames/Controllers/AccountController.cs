namespace GlobalGames.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using GlobalGames.Models;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    

    public class AccountController : Controller
    {

        private readonly IUserAdminHelper userAdminHelper;

        public AccountController(IUserAdminHelper userAdminHelper)
        {
            this.userAdminHelper = userAdminHelper;
        }

        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userAdminHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }

                    return this.RedirectToAction("Index", "JogoInscricoes");
                }
            }
            this.ModelState.AddModelError(string.Empty, "Failed to login");
            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.userAdminHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }

    }
}
