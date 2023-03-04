using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(1000)
               .IsRequired();

        builder.Property(x => x.Pages)
               .IsRequired();

        builder.Property(x => x.Price)
               .HasColumnType("decimal(18,4)")
               .IsRequired();

        builder.HasOne(x => x.Author);

        builder.HasOne(x => x.Department)
               .WithMany(x => x.Books)
               .HasForeignKey(x => x.DepartmentId);
    }
}
