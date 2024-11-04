using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebVivencias.Models;

public partial class VivenciasContext : DbContext
{
    public VivenciasContext()
    {
    }

    public VivenciasContext(DbContextOptions<VivenciasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vivencia> Vivencias { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC076D71D59D");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A19940974B5").IsUnique();

            entity.HasIndex(e => e.Usuario1, "UQ__Usuarios__E3237CF7721FA105").IsUnique();

            entity.Property(e => e.Clave).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");
        });

        modelBuilder.Entity<Vivencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vivencia__3214EC070EF81F68");

            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Vivencia)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vivencias__Usuar__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
