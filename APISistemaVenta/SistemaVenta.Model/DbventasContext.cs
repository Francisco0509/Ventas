using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenta.Model;

public partial class DbventasContext : DbContext
{
    public DbventasContext()
    {
    }

    public DbventasContext(DbContextOptions<DbventasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=DBVentas;User Id=sa;Password=515t3m@5;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CD6018B04");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasColumnName("categoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuarioModificacion");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__BFE2843F964E374B");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleVe__idPro__534D60F1");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DetalleVe__idVen__52593CB8");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PK__Document__572A36FCF4208D80");

            entity.ToTable("Documento");

            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuarioModificacion");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483F610731B");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.Menu1)
                .HasMaxLength(50)
                .HasColumnName("menu");
            entity.Property(e => e.UrlMenu)
                .HasMaxLength(50)
                .HasColumnName("urlMenu");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A451092629");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__3B75D760");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__3C69FB99");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132FE7F7EAD");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");
            entity.Property(e => e.Producto1)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuarioModificacion");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoria)
                .HasConstraintName("FK__Producto__idcate__47DBAE45");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7621290034");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuarioModificacion");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6C546097D");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaModificaicon)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificaicon");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(200)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.UsuarioModificaicon).HasColumnName("usuarioModificaicon");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__3F466844");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__077D56143BA01ADB");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .HasColumnName("tipoPago");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuarioModificacion");
            entity.Property(e => e.UsuarioRegistro).HasColumnName("usuarioRegistro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
