namespace GlobalGames.Dados
{  
    using Entidades;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {

        public DbSet<OrcamentoPedido> PedidosOrcamento { get; set; }



        public DbSet<JogoInscricao> InscricoesJogo { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
