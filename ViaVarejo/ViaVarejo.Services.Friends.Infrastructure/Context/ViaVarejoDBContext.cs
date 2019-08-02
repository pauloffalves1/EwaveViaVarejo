using Microsoft.EntityFrameworkCore;
using ViaVarejo.Services.Friends.Domain;

namespace ViaVarejo.Services.Friends.Infrastructure.Context
{
    public partial class ViaVarejoDBContext : DbContext
    {
        public ViaVarejoDBContext()
        {
        }

        public ViaVarejoDBContext(DbContextOptions<ViaVarejoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friend { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("FRIEND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Latitude).HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");

                //entity.Property(e => e.GeographyPoint).HasColumnName("GEOGRAPHYPOINT");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
