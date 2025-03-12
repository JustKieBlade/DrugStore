using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    /// <summary>
    /// Описание конфигурации DrugStore
    /// </summary>
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(DrugStore.DrugNetwork));

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnName(nameof(DrugStore.Number));

        builder.OwnsOne(x => x.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("City");

            addressBuilder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Street");

            addressBuilder.Property(a => a.House)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("House");

            addressBuilder.Property(a => a.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode");

            addressBuilder.Property(a => a.Iso)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("CountryIso");
        });

    }
}