using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public partial class ExamenContext : DbContext
{
    public ExamenContext()
    {
    }

    public ExamenContext(DbContextOptions<ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<Rutum> Ruta { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pasajero");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdViaje).HasColumnName("ID_Viaje");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.ToTable("Viaje");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdRuta1).HasColumnName("ID_Ruta1");
            entity.Property(e => e.IdRuta2).HasColumnName("ID_Ruta2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
