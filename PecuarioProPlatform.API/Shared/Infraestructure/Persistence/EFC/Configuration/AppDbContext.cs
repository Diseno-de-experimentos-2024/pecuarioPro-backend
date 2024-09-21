using System.Diagnostics;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.IAM.Domain.Model.Aggregates;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;

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
        builder.Entity<District>().HasOne(d => d.City).WithMany().HasForeignKey(d => d.CityId);

        // Properties for City
        builder.Entity<City>().HasKey(c => c.Id);
        builder.Entity<City>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<City>().HasOne(c => c.Department).WithMany().HasForeignKey(c => c.DepartmentId);

        // Properties for Department
        builder.Entity<Department>().HasKey(d => d.Id);
        builder.Entity<Department>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Department>().Property(d => d.Name).IsRequired().HasMaxLength(30);
        
        // Properties for Breed
        builder.Entity<Breed>().HasKey(r => r.Id);
        builder.Entity<Breed>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Breed>().Property(r => r.Name).IsRequired().HasMaxLength(30);
        
        
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
        builder.Entity<Campaign>().OwnsOne(i => i.UserId,
            ui =>
            {
                ui.WithOwner().HasForeignKey("Id");
                ui.Property(p => p.Identifier).HasColumnName("UserId");
            });
        
        //Relationship Bounded Context BusinessAdministration
        builder.Entity<Campaign>().HasMany(c => c.Batches);
        builder.Entity<Campaign>()
            .Property(c => c.DateStart)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v)
            );
        builder.Entity<Campaign>()
            .Property(c => c.DateEnd)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v)
            );


        
        // Properties for Batch
        builder.Entity<Batch>().HasKey(b => b.Id);
        builder.Entity<Batch>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Batch>().Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Batch>().Property(b => b.Area).IsRequired();
        builder.Entity<Batch>().Property(b => b.Status).IsRequired();
        
        builder.Entity<Batch>().OwnsOne(b => b.Origin, origin =>
        {
            origin.Property(o => o.DistrictId).HasColumnName("DistrictId");
            origin.Property(o => o.CityId).HasColumnName("CityId");
            origin.Property(o => o.DepartmentId).HasColumnName("DepartmentId");
        });
        builder.Entity<Batch>().OwnsOne(b => b.Origin, origin =>
        {
            origin.WithOwner().HasForeignKey("Id");
            origin.Property(p => p.DistrictId).HasColumnName("DistrictId");
            origin.Property(p => p.CityId).HasColumnName("CityId");
            origin.Property(p => p.DepartmentId).HasColumnName("DepartmentId");
            
        });
        
        // Properties for Bovine
        builder.Entity<Bovine>().HasKey(b => b.Id);
        builder.Entity<Bovine>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bovine>().Property(b => b.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Bovine>().Property(b => b.Weight).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Date).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Observations).HasMaxLength(400);
        builder.Entity<Bovine>().OwnsOne(b => b.Origin, origin =>
        {
            origin.WithOwner().HasForeignKey("Id");
            origin.Property(p => p.DistrictId).HasColumnName("DistrictId");
            origin.Property(p => p.CityId).HasColumnName("CityId");
            origin.Property(p => p.DepartmentId).HasColumnName("DepartmentId");
            
        });
        builder.Entity<Bovine>().HasMany(bo => bo.Images);

        builder.Entity<Bovine>().HasMany(bo => bo.WeightRecords)
            .WithOne(wr => wr.Bovine)
            .HasForeignKey(wr => wr.BovineId);
        
        builder.Entity<Bovine>().Property(b => b.Date).HasConversion(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v)
        );
        
        builder.Entity<Bovine>().OwnsOne(i => i.UserId,
            ui =>
            {
                ui.WithOwner().HasForeignKey("Id");
                ui.Property(p => p.Identifier).HasColumnName("UserId");
            });
        builder.Entity<Bovine>()
            .HasOne(b => b.Breed) // Bovine tiene una Breed
            .WithMany() // Una Breed puede estar relacionada con varios Bovine
            .HasForeignKey(b => b.BreedId);   // Especifica la clave foránea en la entidad Bovine
   
        
        
        
        //Properties for Vaccine
        builder.Entity<Vaccine>().HasKey(v => v.Id);
        builder.Entity<Vaccine>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(v => v.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Vaccine>().Property(v => v.Date).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Dose).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Code).HasMaxLength(30);
        builder.Entity<Vaccine>().Property(v => v.Reason).HasMaxLength(200);
        builder.Entity<Vaccine>().Property(b => b.Date).HasConversion(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v)
        );
        builder.Entity<Vaccine>().OwnsOne(v => v.UserId,
            ui =>
            {
                ui.WithOwner().HasForeignKey("Id");
                ui.Property(p => p.Identifier).HasColumnName("UserId");
            });
        builder.Entity<Vaccine>().OwnsOne(v => v.BovineId,
            ui =>
            {
                ui.WithOwner().HasForeignKey("Id");
                ui.Property(p => p.Identifier).HasColumnName("BovineId");
            });
        
        //Properties for BovineVaccine
        builder.Entity<BovineVaccine>().HasKey(bv => bv.Id);
        builder.Entity<BovineVaccine>().Property(bv => bv.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BovineVaccine>().Property(bv => bv.VaccinationDate).IsRequired().HasMaxLength(30);
        builder.Entity<BovineVaccine>().Property(bv => bv.BovineId).IsRequired();
        builder.Entity<BovineVaccine>().OwnsOne(bv => bv.VaccineId,
            v =>
            {
                v.WithOwner().HasForeignKey("Id");
                v.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<BovineVaccine>().OwnsOne(bv => bv.StaffId,
            s =>
            {
                s.WithOwner().HasForeignKey("Id");
                s.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });

       
        //Properties for ImageAsset
        builder.Entity<ImageAsset>().HasKey(i => i.Id);
        builder.Entity<ImageAsset>().Property(i => i.Name).HasMaxLength(50);
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();

        builder.Entity<ImageAsset>().OwnsOne(i => i._AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        
        
        
        // Properties for Staff
        
        builder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.JobDescription).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DateStart).IsRequired();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.CampaignId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.DateEnd).HasMaxLength(200);
        });
        
        //Properties for  Veterinarian
        builder.Entity<Veterinarian>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Specialty).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).IsRequired();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.City).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PhotoUrl).HasMaxLength(200);
        });
        
        //properties for Inventory
        
       
        
        // IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
        
    }
}