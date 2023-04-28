using Microsoft.EntityFrameworkCore;

namespace WebApiPersona.Entities
{
    public class ApiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("PersonaAppCon"));
        }
        public DbSet<persona> Personas
        {
            get;
            set;
        }
    }
}
