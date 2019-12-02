using Microsoft.EntityFrameworkCore;
using ProjetoP.WebApi.Controllers.Model;

namespace ProjetoP.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Veiculo> Veiculo { get; set; }
    }
}