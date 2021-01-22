namespace GlobalGames.Dados
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entidades;
    using Helpers;
    using Microsoft.AspNetCore.Identity;


    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserAdminHelper userHelper;
        private readonly Random random;


        public SeedDb(DataContext context, IUserAdminHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }


        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("administrador@emailteste.pt");
            if (user == null)
            {
                user = new UserAdmin
                {
                    FirstName = "adminNome",
                    LastName = "adminPronome",
                    Email = "administrador@emailteste.pt",
                    UserName = "administrador@emailteste.pt",

                };

                var result = await this.userHelper.AddUserAsync(user, "12345678");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.InscricoesJogo.Any())
            {

                await this.context.SaveChangesAsync();

            }
        }

    }

}
