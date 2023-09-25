using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Videojuegos.Data.Models;

namespace Videojuegos.Data;

public partial class VideojuegosContext : DbContext
{
    public VideojuegosContext()
    {
    }

    public VideojuegosContext(DbContextOptions<VideojuegosContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<Juego> Juegos { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__juegosCS__3213E83F97115495");

            entity.ToTable("juegosCSV");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            entity.Property(e => e.Compania)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Consola)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consola");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Formato)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("formato");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idioma");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Saga)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("saga");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
