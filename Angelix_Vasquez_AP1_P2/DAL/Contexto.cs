using Microsoft.EntityFrameworkCore;
using Angelix_Vasquez_AP1_P2.Models;

namespace Angelix_Vasquez_AP1_P2.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Entradas> Entradas { get; set; }
        public virtual DbSet<EntradasDetalle> EntradasDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Entradas y EntradasDetalle
            modelBuilder.Entity<EntradasDetalle>()
                .HasOne(ed => ed.Producto) // Un detalle de entrada tiene un producto
                .WithMany(p => p.EntradasDetalle) // Un producto puede tener muchos detalles de entrada
                .HasForeignKey(ed => ed.ProductoId); // Relacionado por ProductoId

            modelBuilder.Entity<Entradas>()
                .HasMany(e => e.EntradasDetalle)
                .WithOne()
                .HasForeignKey(ed => ed.EntradasId); // Relacionado por EntradasId

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductosId = 1,
                    Descripcion = "Mani",
                    Peso = 12
                },
                new Producto
                {
                    ProductosId = 2,
                    Descripcion = "Almendra",
                    Peso = 17
                },
                new Producto
                {
                    ProductosId = 3,
                    Descripcion = "Pistacho",
                    Peso = 3
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
