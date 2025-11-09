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

                //Relación de muchos a muchos con Artículos
                entity.HasMany(e => e.ClienteArticulos)
                .WithOne(i => i.Cliente)
                .HasForeignKey(i => i.ClienteID);
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Codigo)
                .IsRequired();
                entity.Property(e => e.Precio)
                .HasColumnType("decimal(18,2)");

                //Relación de muchos a muchos con Tienda
                entity.HasMany(e => e.ArticulosTienda)
                .WithOne(i => i.Articulo)
                .HasForeignKey(i => i.ArticuloID);

                //Relación de muchos a muchos con Cliente
                entity.HasMany(e => e.ClienteArticulos)
                .WithOne(i => i.Articulo)
                .HasForeignKey(i => i.ArticuloID);
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sucursal)
                .IsRequired();

                //Relación de muchos a muchos con Artículo
                entity.HasMany(e => e.ArticulosTienda)
                .WithOne(i => i.Tienda)
                .HasForeignKey(i => i.TiendaID);
            });

            modelBuilder.Entity<ArticuloTienda>()
               .HasKey(i => new { i.ArticuloID, i.TiendaID });

            modelBuilder.Entity<ClienteArticulo>()
            .HasKey(i => new { i.ClienteID, i.ArticuloID });

            //Relación de muchos a muchos
            /*modelBuilder.Entity<ClienteArticulo>()
            .HasKey(pg => new { pg.ClienteID, pg.ArticuloID });

            modelBuilder.Entity<ClienteArticulo>()
            .HasOne(pg => pg.Cliente)
            .WithMany(p => p.ClienteArticulos)
            .HasForeignKey(pg => pg.ClienteID);

            modelBuilder.Entity<ClienteArticulo>()
            .HasOne(pg => pg.Articulo)
            .WithMany(p => p.ClienteArticulos)
            .HasForeignKey(pg => pg.ArticuloID);*/

        }
    }
}
