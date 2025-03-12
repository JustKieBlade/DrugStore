using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Dal.Configurations;

namespace Infrastructure.Dal;

/// <summary>
/// Контекст БД
/// </summary>
public class DrugsBotDbContext : DbContext
{
    
    public DbSet<Drug> Drugs { get; init; } = null!;
    
    public DbSet<Country> Countries { get; init; } = null!;
    
    public DbSet<DrugItem> DrugItems { get; init; } = null!;
    
    public DbSet<DrugStore> DrugStores { get; init; } = null!;
    
    public DbSet<FavoriteDrug> FavoriteDrugs { get; init; } = null!;
    
    public DbSet<Profile> Profiles { get; init; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("", (options) =>
        {
            options.CommandTimeout(10);
        });
    }
}