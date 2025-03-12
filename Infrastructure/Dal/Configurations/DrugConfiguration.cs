using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;


public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    /// <summary>
    /// Описание конфигурации Drug
    /// </summary>
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(Drug.Name));

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(Drug.Manufacturer));

        builder.Property(x => x.CountryCodeId)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName(nameof(Drug.CountryCodeId));

        builder.HasOne(x => x.Country)
            .WithMany(y => y.Drugs)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.DrugItems)
            .WithOne(y => y.Drug)
            .HasForeignKey(d => d.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}