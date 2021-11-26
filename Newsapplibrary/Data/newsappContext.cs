using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newsapplibrary.Models;

#nullable disable

namespace Newsapplibrary.Data
{
    public partial class newsappContext : DbContext
    {
        public newsappContext()
        {
        }

        public newsappContext(DbContextOptions<newsappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Fuente> Fuentes { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Idarticulo)
                    .HasName("pk_IDarticulo");

                entity.Property(e => e.Idarticulo).HasColumnName("IDarticulo");

                entity.Property(e => e.Autor)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contenido)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Fechapublicacion).HasColumnType("date");

                entity.Property(e => e.Idcategory).HasColumnName("IDcategory");

                entity.Property(e => e.Idfuente).HasColumnName("IDfuente");

                entity.Property(e => e.Idpais).HasColumnName("IDpais");

                entity.Property(e => e.ImagenUrl)
                    .IsUnicode(false)
                    .HasColumnName("ImagenURL");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.Idcategory)
                    .HasConstraintName("FK_IDcategory");

                entity.HasOne(d => d.IdfuenteNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.Idfuente)
                    .HasConstraintName("FK_IDfuente");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_IDpais");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("pk_IDcategory");

                entity.ToTable("Category");

                entity.Property(e => e.Idcategory).HasColumnName("IDcategory");

                entity.Property(e => e.Nombrecategory)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fuente>(entity =>
            {
                entity.HasKey(e => e.Idfuente)
                    .HasName("pk_IDfuente");

                entity.Property(e => e.Idfuente).HasColumnName("IDfuente");

                entity.Property(e => e.Nombrefuente)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.Idpais)
                    .HasName("pk_IDpais");

                entity.Property(e => e.Idpais).HasColumnName("IDpais");

                entity.Property(e => e.Nombrepais)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
