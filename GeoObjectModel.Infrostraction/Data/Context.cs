using Microsoft.EntityFrameworkCore;
using GeoObjectModel.Domain;

namespace GeoObjectModel.Infrostraction
{
   public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<GeographicalObject> GeographicalObjects { get; set; }
        public DbSet<GeographicalObjectVersion> GeographicalObjectVersions { get; set; }
        public DbSet<GeometryVersion> GeometryVersions { get; set; }
        public DbSet<GeoNamesFeature> GeoNamesFeatures { get; set; }
        public DbSet<NeighboringObjectLink> NeighboringObjectLinks { get; set; }
        public DbSet<ParentChildObjectLink> ParentChildObjectLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /* modelBuilder.Entity<ParentChildObjectLink>()
                 .HasOne(l => l.GeographicalObjectParent)
                 .WithMany(a => a.ParentGeographicalObjects)
                 .HasForeignKey(k => k.GeographicalObjectParentId)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<ParentChildObjectLink>()
                 .HasOne(l => l.GeographicalObjectChild)
                 .WithMany(a => a.ChildGeographicalObjects)
                 .HasForeignKey(k => k.GeographicalObjectChildId)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<ParentChildObjectLink>()
                 .HasOne(l => l.GeographicalObjectChild)
                 .WithMany(a => a.ChildGeographicalObjects)
                 .HasForeignKey(k => k.GeographicalObjectParentId)
                 .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<ParentChildObjectLink>()
                 .HasOne(l => l.GeographicalObjectParent)
                 .WithMany(a => a.ParentGeographicalObjects)
                .HasForeignKey(k => k.GeographicalObjectChildId)
                 .OnDelete(DeleteBehavior.Restrict);*/
            modelBuilder.Entity<GeographicalObject>()
                .HasMany(l => l.ChildGeographicalObjects)
                .WithOne(o => o.GeographicalObjectParent)
                .HasForeignKey(fk => fk.GeographicalObjectParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GeographicalObject>()
                .HasMany(l => l.ParentGeographicalObjects)
                .WithOne(o => o.GeographicalObjectChild)
                .HasForeignKey(fk => fk.GeographicalObjectChildId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NeighboringObjectLink>()
                .HasOne(l => l.NeighboringGeographicalObjectsIn)
                .WithMany(a => a.NeighboringGeographicalObjectsIn)
                .HasForeignKey(k => k.NeighboringGeographicalObjectsInId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NeighboringObjectLink>()
                .HasOne(l => l.NeighboringGeographicalObjectsOut)
                .WithMany(a => a.NeighboringGeographicalObjectsOut)
                .HasForeignKey(k => k.NeighboringGeographicalObjectsOutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GeographicalObject>()
                .Ignore(l => l.Detail);

            modelBuilder.Entity<GeographicalObject>()
                .Ignore(l => l.Geometry);
   
        }

    }
}
