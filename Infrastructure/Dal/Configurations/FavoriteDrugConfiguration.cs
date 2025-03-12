using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    /// <summary>
    /// Описание конфигурации FavoriteDrug
    /// </summary>
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProfileId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.ProfileId));

        builder.Property(x => x.DrugId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.DrugId));

        builder.Property(x => x.DrugStoreId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.DrugStoreId));

        //Связь с таблицами товаров и юзеров (не уверен, что так можно, но по логике юзер может добавить любимый товар себе в профиле
        builder.HasOne(x => x.Profile)
            .WithMany(y => y.FavoriteDrugs)
            .HasForeignKey(d => d.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    
        builder.HasOne(x => x.Drug)
            .WithMany() 
            .HasForeignKey(d => d.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}