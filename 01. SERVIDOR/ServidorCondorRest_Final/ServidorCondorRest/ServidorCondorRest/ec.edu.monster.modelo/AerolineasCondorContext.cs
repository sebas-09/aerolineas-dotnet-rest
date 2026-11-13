using Microsoft.EntityFrameworkCore;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    public class AerolineasCondorContext : DbContext
    {
        public AerolineasCondorContext(DbContextOptions<AerolineasCondorContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación 1:N Usuario-Compra
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.IdUsuario);

            // Relación 1:N Compra-Boleto
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Compra)
                .WithMany(c => c.Boletos)
                .HasForeignKey(b => b.IdCompra);

            // Relación 1:N Vuelo-Boleto
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Vuelo)
                .WithMany(v => v.Boletos)
                .HasForeignKey(b => b.IdVuelo);

            // Relación 1:1 Compra-Factura (Factura dependiente)
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Factura)
                .WithOne(f => f.Compra)
                .HasForeignKey<Factura>(f => f.IdCompra);

            // Relación 1:1 Compra-Pago (Pago dependiente)
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Pago)
                .WithOne(p => p.Compra)
                .HasForeignKey<Pago>(p => p.IdCompra);
        }
    }
}
