using APIClientes.Modelo;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Data
{
    //Se hereda de la clase DbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
