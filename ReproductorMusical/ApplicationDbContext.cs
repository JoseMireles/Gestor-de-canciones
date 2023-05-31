using Microsoft.EntityFrameworkCore;
using ReproductorMusical.Models;

namespace ReproductorMusical
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<Cancion> Cancion { get; set; }
        public DbSet<Playlist> Playlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancion>().HasKey(x => x.Cancion_Id);
            modelBuilder.Entity<Cancion>().Property(x => x.Nombre).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Cancion>().Property(x => x.Autor).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Playlist>().HasKey(x => x.Playlist_Id);
            modelBuilder.Entity<Playlist>().Property(x => x.Nombre).IsRequired().HasMaxLength(30);


            //Fluent API: Uno a muchos
            modelBuilder.Entity<Cancion>()
                .HasOne(x => x.Playlist)
                .WithMany(x => x.Cancion)
                .HasForeignKey(x => x.Playlist_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
