using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasMaxLength(256)
               .IsRequired();
    }
}
