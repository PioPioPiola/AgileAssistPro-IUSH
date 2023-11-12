using System;
using System.Collections.Generic;
using AgileAssistPro_IUSH.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileAssistPro_IUSH.Data;
//ESTE CONTEXT DE BASE DE DATS ESTÁ INHABILITADO AHORA, MÁS TARDE CUANDO HAYA QUE ESCALAR EL PROYECTO, SE USARÁ
public partial class AgileAssistProIushContext : DbContext
{
    public AgileAssistProIushContext()
    {
    }

    public AgileAssistProIushContext(DbContextOptions<AgileAssistProIushContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cursos> Cursos { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cursos>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Cursos__085F27D686520ACB");

            entity.Property(e => e.IdCurso).ValueGeneratedNever();
            entity.Property(e => e.Docente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Rol);

            entity.Property(e => e.Rol)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Correo)
                .HasMaxLength(70)
                .IsFixedLength();
            entity.Property(e => e.IdCurso)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
