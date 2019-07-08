using ApplicationCore.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.DataLayer.EntityFramework
{
    public class ApplicationCoreContext : IdentityDbContext<User>
    {
        public ApplicationCoreContext(DbContextOptions<ApplicationCoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<EntityLog> EntityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(x => new { x.Id });
            builder.Entity<EntityLog>().HasKey(x => new { x.Id });
            base.OnModelCreating(builder);
        }
    }
}
