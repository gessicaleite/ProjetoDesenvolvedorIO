using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ProjetoDesenvolvedor.IO.Data
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
