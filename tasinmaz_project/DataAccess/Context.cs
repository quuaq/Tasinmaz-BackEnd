using Microsoft.EntityFrameworkCore;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.DataAccess
{
    public class Context : DbContext
    {
        // Yapıcı Metot
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        //Mahalle POST için eklendi.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mahalle>()
                .HasOne(m => m.Ilce)
                .WithMany()
                .HasForeignKey(m => m.ilce_id);

            modelBuilder.Entity<Ilce>()
                .HasOne(i => i.Sehir)
                .WithMany()
                .HasForeignKey(i => i.sehir_id);
        }

        public DbSet<Kullanici> kullanici { get; set; }
        public DbSet<Ilce> ilce { get; set; }
        public DbSet<Sehir> sehir { get; set; }
        public DbSet<Mahalle> mahalle { get; set; }
        public DbSet<Tasinmaz> tasinmaz { get; set; }
        public DbSet<Log> log { get; set; }
    }


    
}
