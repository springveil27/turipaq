using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;

namespace turipaq.Database
{

        public class DataContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-BRC4FS3\SQLEXPRESS;Database=turipaq;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<PaqueteTuristico> Paquete_Turisticos { get; set; }
            public DbSet<Pago> Pagos { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaqueteTuristico>()
                .HasKey(p => p.PaqueteId);  

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.ReservaId);

            modelBuilder.Entity<Pago>()
                .HasKey(r => r.PagoId);
        }

    }

}



