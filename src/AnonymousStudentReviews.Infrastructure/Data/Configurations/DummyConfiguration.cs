using AnonymousStudentReviews.Core.DummyAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnonymousStudentReviews.Infrastructure.Data.Configurations;

public class DummyConfiguration : IEntityTypeConfiguration<Dummy>
{
    public void Configure(EntityTypeBuilder<Dummy> builder)
    {
        builder.ToTable("dummies");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(20)
            .IsRequired();
    }
}
