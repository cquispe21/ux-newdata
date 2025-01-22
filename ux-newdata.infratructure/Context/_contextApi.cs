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

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97DEEBD27C");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105343B000176").IsUnique();

                entity.Property(e => e.IdUsuario).HasMaxLength(300);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(300);
                entity.Property(e => e.Salt).HasMaxLength(100);
                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
