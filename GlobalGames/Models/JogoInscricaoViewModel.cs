namespace GlobalGames.Models
{
    using System.ComponentModel.DataAnnotations;
    using Dados.Entidades;
    using Microsoft.AspNetCore.Http;
    

    public class JogoInscricaoViewModel : JogoInscricao
    {
        [Display(Name="Avatar")]
        public IFormFile ImageFile { get; set; }
    }
}
