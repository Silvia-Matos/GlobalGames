using GlobalGames.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GlobalGames.Dados
{
    public class DataContext : DbContext
    {

        public DbSet<OrcamentoPedido> PedidosOrcamento { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
