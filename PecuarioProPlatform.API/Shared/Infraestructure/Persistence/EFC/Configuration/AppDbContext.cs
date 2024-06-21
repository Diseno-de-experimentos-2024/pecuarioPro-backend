using System.Diagnostics;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities.vaccine;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.StaffManagement.Domain.Model.Aggregates;

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
        
        // Properties for Race
        builder.Entity<Race>().HasKey(r => r.Id);
        builder.Entity<Race>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Race>().Property(r => r.Name).IsRequired().HasMaxLength(30);
        
        
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
        
        builder.Entity<Batch>().OwnsOne(b => b.Origin, origin =>
        {
            origin.Property(o => o.DistrictId).HasColumnName("DistrictId");
            origin.Property(o => o.CityId).HasColumnName("CityId");
            origin.Property(o => o.DepartmentId).HasColumnName("DepartmentId");
        });
        
        
        // Properties for Bovine
        builder.Entity<Bovine>().HasKey(b => b.Id);
        builder.Entity<Bovine>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bovine>().Property(b => b.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Bovine>().Property(b => b.Weight).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Date).IsRequired();
        builder.Entity<Bovine>().Property(b => b.Observations).HasMaxLength(400);
        
      
        
        
        
        
        /*
        //Properties For Vaccine
        builder.Entity<Vaccine>().HasKey(v => v.Id);
        builder.Entity<Vaccine>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(v => v.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Vaccine>().Property(v => v.Reason).HasMaxLength(100);
        builder.Entity<Vaccine>().Property(v => v.Date).IsRequired();
*/
        
        
        
        //Properties for Vaccine
        
        builder.Entity<Vaccines>().HasKey(v => v.Id);
        builder.Entity<Vaccines>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccines>().Property(v => v.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Vaccines>().Property(v => v.Reason).HasMaxLength(100);
        builder.Entity<Vaccines>().Property(v => v.Code).IsRequired().HasMaxLength(100);
        builder.Entity<Vaccines>().Property(v => v.Description).IsRequired().HasMaxLength(225);
        
        
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
        builder.Entity<ImageAsset>().Property(i => i.Name).HasMaxLength(50);
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();

        builder.Entity<ImageAsset>().OwnsOne(i => i._AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        
        
        builder.Entity<Bovine>().OwnsOne(b => b.Origin, origin =>
        {
            origin.WithOwner().HasForeignKey("Id");
            origin.Property(p => p.DistrictId).HasColumnName("DistrictId");
            origin.Property(p => p.CityId).HasColumnName("CityId");
            origin.Property(p => p.DepartmentId).HasColumnName("DepartmentId");
            
        });
        
        builder.Entity<Batch>().OwnsOne(b => b.Origin, origin =>
        {
            origin.WithOwner().HasForeignKey("Id");
            origin.Property(p => p.DistrictId).HasColumnName("DistrictId");
            origin.Property(p => p.CityId).HasColumnName("CityId");
            origin.Property(p => p.DepartmentId).HasColumnName("DepartmentId");
            
        });
        
        
        //Relationship Bounded Context BusinessAdministration
        builder.Entity<Campaign>().HasMany(c => c.Batches);
        
        builder.Entity<Bovine>().HasMany(bo => bo.Images);

        builder.Entity<Bovine>().HasMany(bo => bo.WeightRecords)
            .WithOne(wr => wr.Bovine)
            .HasForeignKey(wr => wr.BovineId);
        
        
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


        builder.Entity<Bovine>().Property(b => b.Date).HasConversion(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v)
        );
        
        // Properties for Staff
        
        builder.Entity<Staff>().HasKey(s => s.Id);
        builder.Entity<Staff>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Staff>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Staff>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Staff>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });
        
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
        
    }
}