using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace KEEM_DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Poi> Pois { get; set; } 
        public DbSet<Emission> Emissions { get; set; }
        public DbSet<Gdk> Gdks { get; set; }

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

                entity.HasOne(e => e.Element)
                .WithMany(e => e.Emissions)
                .HasForeignKey(e => e.IdElement);
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

            builder.Entity<Element>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Primary");

                entity.ToTable("elements");

                entity.Property(e => e.Id).HasColumnName("code");
                entity.Property(e => e.Cas).HasColumnName("cas");
                entity.Property(e => e.Formula).HasColumnName("formula");
                entity.Property(e => e.isHydrocarbon).HasColumnName("hydrocarbon");
                entity.Property(e => e.Measure).HasColumnName("measure");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.isRigid).HasColumnName("rigid");
                entity.Property(e => e.ShortName).HasColumnName("short_name");
                entity.Property(e => e.isVoc).HasColumnName("voc");                          
            });

            builder.Entity<Gdk>(entity =>
            {
                entity.HasKey(g => g.Id).HasName("Primary");

                entity.ToTable("gdk");

                entity.Property(e => e.Id).HasColumnName("code");
                entity.Property(e => e.DangerCLass).HasColumnName("danger_class");
                entity.Property(e => e.Environment).HasColumnName("environment");
                entity.Property(e => e.MpcAverage_D).HasColumnName("mpc_avrg_d");
                entity.Property(e => e.MpcM_Ot).HasColumnName("mpc_m_ot");
                entity.Property(e => e.Tsel).HasColumnName("tsel");
            });
        }
    }
}
