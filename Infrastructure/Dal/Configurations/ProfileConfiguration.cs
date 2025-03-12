using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    /// <summary>
    /// Описание конфигурации Profile
    /// </summary>
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExternalId)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(Profile.ExternalId));

        // Настройка связи для значения-объекта Email
        builder.OwnsOne(x => x.Email, emailBuilder =>
        {
            emailBuilder.Property(e => e.Value)
                .HasColumnName("Email");
        });

        // Связь с FavoriteDrug
        builder.HasMany(x => x.FavoriteDrugs)
            .WithOne(y => y.Profile)
            .HasForeignKey(d => d.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}