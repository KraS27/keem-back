using KEEM_Domain.Entities.DB;
using Microsoft.EntityFrameworkCore;


namespace KEEM_DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Poi> pois { get; set; } 

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
                entity.Property(p => p.Latitude).HasColumnName("CoordLat");
                entity.Property(p => p.Longitude).HasColumnName("CoordLng");
                entity.Property(p => p.Description).HasColumnName("Description");
                entity.Property(p => p.NameObject).HasColumnName("Name_Object");
            });
        }
    }
}
