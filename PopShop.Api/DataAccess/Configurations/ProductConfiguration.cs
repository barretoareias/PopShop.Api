using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopShop.Api.DataAccess;
using PopShop.Api.Models;

namespace PopShop.Api.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Produto", DataContext.SCHEMA)
               .HasKey(e => e.Id)
               .HasName("Id");

        builder.Property(e => e.Name)
               .HasColumnName("Nome")
               .IsRequired()
               .HasMaxLength(150);

        builder.Ignore(e => e.Price);
        /*builder.Property(e => e.Price)
               .HasColumnName("Pecro")
               .IsRequired()
               .HasPrecision(10, 2);*/

        builder.Property(e => e.Description)
               .HasColumnName("Descricao")
               .IsRequired();

        builder.Property(e => e.CreationDate)
               .HasColumnName("DataCriacao")
               .IsRequired();

        builder.Property(e => e.Active)
               .HasColumnName("Ativo")
               .IsRequired();

        builder.Ignore(e => e.Store);
    }
}