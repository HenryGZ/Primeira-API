using Microsoft.EntityFrameworkCore;
using Primeira_API.Model;

namespace Primeira_API.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } //indica que a tabela Employee será criada no banco de dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +
                "Port=5432;" +
                "Database=employee;" +
                "Username=postgres;" +
                "Password=@Henry123a");
        }
    }
}
