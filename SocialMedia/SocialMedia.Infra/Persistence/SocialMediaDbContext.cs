using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Infra.Persistence.Mappings;

namespace SocialMedia.Infra.Persistence
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) 
            : base(options) { }


        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContaMap());

            base.OnModelCreating(builder);
        }

    }
}
