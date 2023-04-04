using AWWW_lab2_gr5.Models;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Article - Comment relationship
            modelBuilder
                .Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Author - Article relationship
            modelBuilder
                .Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(au => au.Articles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category - Article relationship
            modelBuilder
                .Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Aricles)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tag - Article relationship
            modelBuilder
                .Entity<Tag>()
                .HasMany(t => t.Artciles)
                .WithMany(a => a.Tags)
                .UsingEntity(j => j.ToTable("ArticleTag"));

            // Match - Article relationship
            modelBuilder
                .Entity<Article>()
                .HasOne(a => a.Match)
                .WithMany(m => m.Articles)
                .HasForeignKey(a => a.MatchId)
                .IsRequired(false);

            // Match - Team relationship
            modelBuilder
                .Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            // Team - League realtionship
            modelBuilder
                .Entity<Team>()
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Team - Player relationship
            modelBuilder
                .Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Match - MatchEvent relationship
            modelBuilder
                .Entity<MatchEvent>()
                .HasOne(me => me.Match)
                .WithMany(m => m.MatchEvents)
                .HasForeignKey(me=> me.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Match - MatchPlayer relationship
            modelBuilder
                .Entity<MatchPlayer>()
                .HasOne(mp => mp.Match)
                .WithMany(m => m.MatchPlayers)
                .HasForeignKey(mp => mp.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // MatchPlayer - MatchEvent relationship
            modelBuilder
                .Entity<MatchEvent>()
                .HasOne(me => me.MatchPlayer)
                .WithMany(mp => mp.MatchEvents)
                .HasForeignKey(me => me.MatchPlayerId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            // MatchEvent - EventType relationship
            modelBuilder
                .Entity<MatchEvent>()
                .HasOne(me => me.EventType)
                .WithMany(et => et.MatchEvents)
                .HasForeignKey(me => me.EventTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // MatchPlayer - Position relationship
            modelBuilder
                .Entity<MatchPlayer>()
                .HasOne(mp => mp.Position)
                .WithMany(p => p.MatchPlayers)
                .HasForeignKey(mp => mp.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            // MatchPlayer - Player relationship
            modelBuilder
                .Entity<MatchPlayer>()
                .HasOne(mp => mp.Player)
                .WithMany(p => p.MatchPlayers)
                .HasForeignKey(mp => mp.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Position - Player relationship
            modelBuilder
                .Entity<Position>()
                .HasMany(po => po.Players)
                .WithMany(pl => pl.Positions)
                .UsingEntity(j => j.ToTable("PositionPlayer"));
        }
    }
}
