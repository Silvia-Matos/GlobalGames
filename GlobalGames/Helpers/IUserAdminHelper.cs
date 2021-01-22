namespace GlobalGames.Helpers
{
    using System.Threading.Tasks;
    using Dados.Entidades;
    using Models;
    using Microsoft.AspNetCore.Identity;

    public interface IUserAdminHelper
    {
        Task<UserAdmin> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserAdmin userAdmin, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

    }
}
