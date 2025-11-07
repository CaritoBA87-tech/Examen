using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen.Entity.Entities;

namespace Examen.Data.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<ClienteArticulo> ClientesArticulos { get; set; }
        public DbSet<ArticuloTienda> ArticulosTiendas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                .IsRequired();
                entity.Property(e => e.Apellido)
                .IsRequired();
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Codigo)
                .IsRequired();
                entity.Property(e => e.Precio)
                .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sucursal)
                .IsRequired();
            });

            //Relación de muchos a muchos
            modelBuilder.Entity<ClienteArticulo>()
            .HasKey(pg => new { pg.ClienteID, pg.ArticuloID });

            modelBuilder.Entity<ClienteArticulo>()
            .HasOne(pg => pg.Cliente)
            .WithMany(p => p.ClienteArticulos)
            .HasForeignKey(pg => pg.ClienteID);

            modelBuilder.Entity<ClienteArticulo>()
            .HasOne(pg => pg.Articulo)
            .WithMany(p => p.ClienteArticulos)
            .HasForeignKey(pg => pg.ArticuloID);

            //Relación de muchos a muchos
            modelBuilder.Entity<ArticuloTienda>()
            .HasKey(pg => new { pg.ArticuloID, pg.TiendaID });

            modelBuilder.Entity<ArticuloTienda>()
            .HasOne(pg => pg.Articulo)
            .WithMany(p => p.ArticulosTienda)
            .HasForeignKey(pg => pg.ArticuloID);

            modelBuilder.Entity<ArticuloTienda>()
            .HasOne(pg => pg.Tienda)
            .WithMany(p => p.ArticulosTienda)
            .HasForeignKey(pg => pg.TiendaID);

        }
    }
}
