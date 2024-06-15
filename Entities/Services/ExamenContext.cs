using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Services;

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

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pasajero");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdViaje).HasColumnName("ID_Viaje");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Pasajeros)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Viaje");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdViaje).HasColumnName("ID_Viaje");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Viaje");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.ToTable("Viaje");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdRuta1).HasColumnName("ID_Ruta1");
            entity.Property(e => e.IdRuta2).HasColumnName("ID_Ruta2");

            entity.HasOne(d => d.IdRuta1Navigation).WithMany(p => p.ViajeIdRuta1Navigations)
                .HasForeignKey(d => d.IdRuta1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Ruta1");

            entity.HasOne(d => d.IdRuta2Navigation).WithMany(p => p.ViajeIdRuta2Navigations)
                .HasForeignKey(d => d.IdRuta2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Ruta2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
