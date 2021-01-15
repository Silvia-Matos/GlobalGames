namespace GlobalGames.Dados.Entidades
{   
    using System;
    using System.ComponentModel.DataAnnotations;


    public class JogoInscricao
    {
        public int Id { get; set; }


        public string Nome { get; set; }


        public string Apelido { get; set; }


        public string Morada { get; set; }


        public string Localidade { get; set; }


        public string CC { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
