namespace GlobalGames.Helpers
{
    using GlobalGames.Dados.Entidades;
    using GlobalGames.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;


    public class UserAdminHelper : IUserAdminHelper
    {

        private readonly UserManager<UserAdmin> userManager;
        private readonly SignInManager<UserAdmin> signInManager;

        public UserAdminHelper(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(UserAdmin userAdmin, string password)
        {
            return await this.userManager.CreateAsync(userAdmin, password);
        }

        public async Task<UserAdmin> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        
    }
}
