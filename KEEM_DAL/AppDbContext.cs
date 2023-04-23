﻿using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace KEEM_DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Poi> Pois { get; set; } 
        public DbSet<Emission> Emissions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Poi>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("Primary");

                entity.ToTable("poi");

                entity.Property(p => p.Id).HasColumnName("Id");
                entity.Property(p => p.IdOfUser).HasColumnName("id_of_user");
                entity.Property(p => p.Type).HasColumnName("Type");
                entity.Property(p => p.OwnerType).HasColumnName("owner_type");
                entity.Property(p => p.Latitude).HasColumnName("Coord_Lat");
                entity.Property(p => p.Longitude).HasColumnName("Coord_Lng");
                entity.Property(p => p.Description).HasColumnName("Description");
                entity.Property(p => p.NameObject).HasColumnName("Name_Object");

                entity.HasOne(p => p.TypeOfObject)
                .WithMany(t => t.Pois)
                .HasForeignKey(p => p.Type);

                entity.HasMany(p => p.Emissions)
                .WithOne(e => e.Poi)
                .HasForeignKey(e => e.IdPoi);
            });

            builder.Entity<Emission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Primary");

                entity.ToTable("emissions_on_map");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Day).HasColumnName("day");
                entity.Property(e => e.IdElement).HasColumnName("idElement");
                entity.Property(e => e.IdEnvironment).HasColumnName("idEnvironment");
                entity.Property(e => e.IdPoi).HasColumnName("idPoi");
                entity.Property(e => e.IdPoligon).HasColumnName("idPoligon");
                entity.Property(e => e.Measure).HasColumnName("Measure");
                entity.Property(e => e.Month).HasColumnName("Month");
                entity.Property(e => e.ValueAvg).HasColumnName("ValueAvg");
                entity.Property(e => e.ValueMax).HasColumnName("ValueMax");
                entity.Property(e => e.Year).HasColumnName("Year");

                entity.HasOne(e => e.Poi)
                .WithMany(p => p.Emissions)
                .HasForeignKey(e => e.IdPoi);
            });

            builder.Entity<TypeOfObject>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Primary");

                entity.ToTable("type_of_object");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ImageName).HasColumnName("Image_Name");
                entity.Property(e => e.Kved).HasColumnName("kved");
                entity.Property(e => e.Name).HasColumnName("Name");
            });
        }
    }
}
