using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;

namespace PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //to edit
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Properties for District
        builder.Entity<District>().HasKey(d => d.Id);
        builder.Entity<District>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<District>().Property(d => d.Name).IsRequired().HasMaxLength(30);
        
        
        // Properties for City
        builder.Entity<City>().HasKey(c => c.Id);
        builder.Entity<City>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        

        // Properties for Department
        builder.Entity<Department>().HasKey(d => d.Id);
        builder.Entity<Department>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Department>().Property(d => d.Name).IsRequired().HasMaxLength(30);

        builder.Entity<Department>().HasMany(d => d.Cities);
        builder.Entity<City>().HasMany(c => c.Districts);
        
        
        
        // BusinessAdministration context
        //Properties for Campaign
        builder.Entity<Campaign>().HasKey(c => c.Id);
        builder.Entity<Campaign>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Campaign>().Property(c => c.Name).IsRequired().HasMaxLength(50);;
        builder.Entity<Campaign>().Property(c => c.DateStart).IsRequired();
        builder.Entity<Campaign>().Property(c => c.DateEnd).IsRequired();
        builder.Entity<Campaign>().Property(c => c.Objective).IsRequired().HasMaxLength(200);;
        builder.Entity<Campaign>().Property(c => c.Condition).HasMaxLength(50);;
        builder.Entity<Campaign>().Property(c => c.Duration);
        
        
        // Properties for Batch
        builder.Entity<Batch>().HasKey(b => b.Id);
        builder.Entity<Batch>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Batch>().Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Batch>().Property(b => b.Area).IsRequired();
        builder.Entity<Batch>().Property(b => b.Status).IsRequired();
        
        // Properties for Bovine
        builder.Entity<Bovine>().HasKey(b => b.Id);
        builder.Entity<Bovine>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bovine>().Property(b => b.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Bovine>().Property(b => b.Weight).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Date).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Observations).HasMaxLength(400);

       
        //Properties for ImageAsset
        builder.Entity<ImageAsset>().Property(i => i.Name).HasMaxLength(50);
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();

        builder.Entity<ImageAsset>().OwnsOne(i => i._AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        
        
        //Relationship Bounded Context BusinessAdministration
        builder.Entity<Campaign>().HasMany(c => c.Batches);
        builder.Entity<Batch>().HasMany(b => b.Bovines);
        builder.Entity<Bovine>().HasMany(bo => bo.Vaccines);
        builder.Entity<Bovine>().HasMany(bo => bo.Images);
        
        
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}