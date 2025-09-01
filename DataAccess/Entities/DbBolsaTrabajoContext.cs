using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class DbBolsaTrabajoContext : DbContext
{
    public DbBolsaTrabajoContext()
    {
    }

    public DbBolsaTrabajoContext(DbContextOptions<DbBolsaTrabajoContext> options)
        : base(options)
    {
    }



    //ACA SE AGREGAN LAS TABLAS
    public virtual DbSet<Prueba> Prueba { get; set; }
    public virtual DbSet<EstadoOferta> EstadoOferta { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

          modelBuilder.Entity<Prueba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Prueba");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Email).HasColumnName("email").IsRequired();
        
        });

        modelBuilder.Entity<Oferta>(e =>
        {
            e.ToTable("Oferta");
            e.HasKey(x => x.Id);

            // columnas primitivas
            e.Property(x => x.Id).HasColumnName("Id");
            e.Property(x => x.IdPerfilEmpresa).HasColumnName("IdPerfilEmpresa");
            e.Property(x => x.Titulo).HasColumnName("Titulo").IsRequired();
            e.Property(x => x.Descripcion).HasColumnName("Descripcion");
            e.Property(x => x.IdModalidad).HasColumnName("IdModalidad");
            e.Property(x => x.IdTipoContrato).HasColumnName("IdTipoContrato");
            e.Property(x => x.FechaInicio).HasColumnName("FechaInicio");
            e.Property(x => x.FechaFin).HasColumnName("FechaFin");
            e.Property(x => x.IdLocalidad).HasColumnName("IdLocalidad");
            e.Property(x => x.FechaAlta).HasColumnName("FechaAlta");
            e.Property(x => x.FechaModificacion).HasColumnName("FechaModificacion");
            e.Property(x => x.FechaBaja).HasColumnName("FechaBaja");

            // FKs: decirle a EF que la FK es IdXxx (no XxxId)
            e.HasOne(x => x.PerfilEmpresa)
            .WithMany(p => p.Ofertas)
            .HasForeignKey(x => x.IdPerfilEmpresa);

            e.HasOne(x => x.Modalidad)
            .WithMany(m => m.Ofertas)
            .HasForeignKey(x => x.IdModalidad);

            e.HasOne(x => x.TipoContrato)
            .WithMany(t => t.Ofertas)
            .HasForeignKey(x => x.IdTipoContrato);

            e.HasOne(x => x.Localidad)
            .WithMany(l => l.Ofertas)
            .HasForeignKey(x => x.IdLocalidad);
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
