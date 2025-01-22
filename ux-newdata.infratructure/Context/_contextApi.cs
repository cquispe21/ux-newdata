using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.Models;

namespace ux_newdata.infratructure.Context
{
    public partial class _contextApi : DbContext
    {
        public _contextApi()
        {
        }

        public _contextApi(DbContextOptions<_contextApi> options)
            : base(options)
        {
        }
        public virtual DbSet<Habitaciones> Habitaciones { get; set; }

        public virtual DbSet<Hoteles> Hoteles { get; set; }

        public virtual DbSet<Reservas> Reservas { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitaciones>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion).HasName("habitaciones_pkey");

                entity.ToTable("habitaciones");

                entity.Property(e => e.IdHabitacion)
                    .ValueGeneratedNever()
                    .HasColumnName("idHabitacion");
                entity.Property(e => e.Capacidad).HasColumnName("capacidad");
                entity.Property(e => e.Disponibilidad)
                    .HasDefaultValue(true)
                    .HasColumnName("disponibilidad");
                entity.Property(e => e.IdHotel).HasColumnName("idHotel");
                entity.Property(e => e.NumeroHabitacion)
                    .HasMaxLength(20)
                    .HasColumnName("numeroHabitacion");
                entity.Property(e => e.PrecioNoche)
                    .HasPrecision(10, 2)
                    .HasColumnName("precioNoche");
                entity.Property(e => e.TipoHabitacion)
                    .HasMaxLength(20)
                    .HasColumnName("tipoHabitacion");

                entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.IdHotel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("habitaciones_idHotel_fkey");
            });

            modelBuilder.Entity<Hoteles>(entity =>
            {
                entity.HasKey(e => e.IdHotel).HasName("hoteles_pkey");

                entity.ToTable("hoteles");

                entity.Property(e => e.IdHotel)
                    .ValueGeneratedNever()
                    .HasColumnName("idHotel");
                entity.Property(e => e.Categoria).HasColumnName("categoria");
                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .HasColumnName("ciudad");
                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .HasColumnName("contacto");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.Direccion).HasColumnName("direccion");
                entity.Property(e => e.NombreHotel)
                    .HasMaxLength(100)
                    .HasColumnName("nombreHotel");
                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .HasColumnName("pais");
                entity.Property(e => e.Politicas).HasColumnName("politicas");
            });

            modelBuilder.Entity<Reservas>(entity =>
            {
                entity.HasKey(e => e.IdReserva).HasName("reservas_pkey");

                entity.ToTable("reservas");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");
                entity.Property(e => e.EstadoReserva)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'pendiente'::character varying")
                    .HasColumnName("estadoReserva");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fechaCreacion");
                entity.Property(e => e.FechaEntrada).HasColumnName("fechaEntrada");
                entity.Property(e => e.FechaSalida).HasColumnName("fechaSalida");
                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");
                entity.Property(e => e.IdHhotel).HasColumnName("idHhotel");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.PrecioTotal)
                    .HasPrecision(10, 2)
                    .HasColumnName("precioTotal");

                entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reservas_idHabitacion_fkey");

                entity.HasOne(d => d.IdHhotelNavigation).WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdHhotel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reservas_idHhotel_fkey");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reservas_idUsuario_fkey");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Correo, "usuarios_correo_key").IsUnique();

                entity.HasIndex(e => e.UserName, "usuarios_userName_key").IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idUsuario");
                entity.Property(e => e.Clave)
                    .HasMaxLength(255)
                    .HasColumnName("clave");
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");
                entity.Property(e => e.FechaCreacion).HasColumnType("timestamp without time zone");
                entity.Property(e => e.NombresCompletos)
                    .HasMaxLength(255)
                    .HasColumnName("nombresCompletos");
                entity.Property(e => e.Salt)
                    .HasMaxLength(250)
                    .HasColumnName("salt");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasColumnName("telefono");
                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'cliente'::character varying")
                    .HasColumnName("tipoUsuario");
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
