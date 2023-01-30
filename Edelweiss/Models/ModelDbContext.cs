using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Edelweiss.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Collaboratori> Collaboratori { get; set; }
        public virtual DbSet<Contatti> Contatti { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Pacchetti> Pacchetti { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordini>()
                .Property(e => e.PrezzoAcquisto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pacchetti>()
                .Property(e => e.PrezzoScontato)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pacchetti>()
                .Property(e => e.PrezzoEffettivo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pacchetti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Pacchetti)
                .WillCascadeOnDelete(false);
        }
    }
}
