using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Models;

namespace SmartLogis.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallesEnvio>()
                .HasOne(d => d.Estatus)
                .WithMany()
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cliente>()
                .HasOne(d => d.Estatus)
                .WithMany()
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rutas>()
                .HasOne(d => d.Estatus)
                .WithMany()
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transportista>()
                .HasOne(d => d.Estatus)
                .WithMany()
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.IdCliente)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetallesEnvio>()
                .HasOne(d => d.Transportista)
                .WithMany()
                .HasForeignKey(d => d.IdTransportista)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetallesEnvio>()
                .HasOne(d => d.Envio)
                .WithMany()
                .HasForeignKey(d => d.IdEnvio)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetallesEnvio>()
                .HasOne(d => d.Rutas)
                .WithMany()
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
        public DbSet<DetallesEnvio> DetallesEnvio { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<EstatusEnvio> EstatusEnvio { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Transportista> Transportista { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}