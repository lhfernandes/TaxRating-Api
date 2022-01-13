using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TaxRatingContext : DbContext
    {
        public TaxRatingContext(DbContextOptions<TaxRatingContext> options)
            : base(options)
        { }

        public DbSet<Segment> Segment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxRatingContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
