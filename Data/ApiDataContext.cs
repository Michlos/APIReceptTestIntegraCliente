using IntegraCliente.Model;

using Microsoft.EntityFrameworkCore;

namespace IntegraCliente.Data
{
    public class ApiDataContext: DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>();
        }
    }
}
