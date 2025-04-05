using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public DbSet<Clientes> Clientes { get; set; }
            public DbSet<PaqueteTuristico> Paquete_Turisticos { get; set; }
            public DbSet<Pago> Pagos { get; set; }
            public DbSet<Reserva> Reservas { get; set; }
       
       }

}



