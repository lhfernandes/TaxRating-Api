using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class SegmentMapping : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.ToTable("segmento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.Created);

            builder.Property(x => x.Updated);

            builder.Property(x => x.Tax)
                .HasColumnType("decimal(8,3)")
                .IsRequired();
        }
    }
}
