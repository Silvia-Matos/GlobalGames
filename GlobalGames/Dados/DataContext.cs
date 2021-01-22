namespace GlobalGames.Dados
{  
    using Entidades;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<UserAdmin>
    {

        public DbSet<OrcamentoPedido> PedidosOrcamento { get; set; }



        public DbSet<JogoInscricao> InscricoesJogo { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
