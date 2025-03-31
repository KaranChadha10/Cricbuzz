using CribBuzz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CribBuzz.Infrastructure.Data
{
    public class CribBuzzDbContext : DbContext
    {
        public CribBuzzDbContext(DbContextOptions<CribBuzzDbContext> options) : base(options) { }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<LiveScore> LiveScores { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<MatchPlayers> MatchPlayers { get; set; }  // ✅ Now it exists
        public DbSet<NewsArticle> NewsArticles { get; set; }  // ✅ Now it exists

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatchPlayers>()
            .HasKey(mp => new { mp.MatchId, mp.PlayerId });

        // Team1 relationship
        modelBuilder.Entity<Match>()
            .HasOne(m => m.Team1)
            .WithMany()
            .HasForeignKey(m => m.Team1Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Team2 relationship
        modelBuilder.Entity<Match>()
            .HasOne(m => m.Team2)
            .WithMany()
            .HasForeignKey(m => m.Team2Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // WinnerTeam relationship (make this optional)
        modelBuilder.Entity<Match>()
            .HasOne(m => m.WinnerTeam)
            .WithMany()
            .HasForeignKey(m => m.WinnerTeamId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false); // Make winner optional

        modelBuilder.Entity<Commentary>()
            .HasOne(c => c.Match)
            .WithMany()
            .HasForeignKey(c => c.MatchId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

        modelBuilder.Entity<Commentary>()
            .HasOne(c => c.Batsman)
            .WithMany()
            .HasForeignKey(c => c.BatsmanId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Commentary>()
            .HasOne(c => c.Bowler)
            .WithMany()
            .HasForeignKey(c => c.BowlerId)
            .OnDelete(DeleteBehavior.Restrict);


        base.OnModelCreating(modelBuilder);
        }
    }
}
