using Microsoft.EntityFrameworkCore;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class RepartitionTournoiContext : DbContext
    {
        public RepartitionTournoiContext()
        {
        }

        public RepartitionTournoiContext(DbContextOptions<RepartitionTournoiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jeu> Jeus { get; set; } = null!;
        public virtual DbSet<Joueur> Joueurs { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Score> Scores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jeu>(entity =>
            {
                entity.ToTable("Jeu");

                entity.Property(e => e.Nom).HasMaxLength(100);
            });

            modelBuilder.Entity<Joueur>(entity =>
            {
                entity.ToTable("Joueur");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Prénom).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.JeuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__JeuId__3C69FB99");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.JoueurId })
                    .HasName("PK_Person");

                entity.ToTable("Score");

                entity.HasOne(d => d.Joueur)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.JoueurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Joueur");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
