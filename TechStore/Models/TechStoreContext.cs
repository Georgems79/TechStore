using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Models;

public partial class TechStoreContext : DbContext
{
    public TechStoreContext()
    {
    }

    public TechStoreContext(DbContextOptions<TechStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
        }
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TechStore;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1026005F60");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__0988921093BA7EA8");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoxCategorium",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__Productox__IdCat__2A4B4B5E"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK__Productox__IdPro__29572725"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdCategoria").HasName("PK__Producto__13B490B1E4053D53");
                        j.ToTable("ProductoxCategoria");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97306DA979");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
