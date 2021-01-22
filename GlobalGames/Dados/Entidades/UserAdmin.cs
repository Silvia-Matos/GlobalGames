namespace GlobalGames.Dados.Entidades
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class UserAdmin : IdentityUser
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static implicit operator string(UserAdmin v)
        {
            throw new NotImplementedException();
        }
    }
}
