using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Librery.Models
{
    public partial class ApplicationDB : DbContext
    {
        public ApplicationDB()
            : base("name=ApplicationDB")
        {
        }

        public virtual DbSet<editoriales> editoriales { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<editoriales>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Libros>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Libros>()
                .Property(e => e.autor)
                .IsUnicode(false);

            modelBuilder.Entity<Libros>()
                .Property(e => e.precio)
                .HasPrecision(5, 2);
        }
    }
}
