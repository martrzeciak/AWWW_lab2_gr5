namespace AWWW_lab2_gr5.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }

        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

        public virtual ICollection<MatchEvent> MatchEvents { get; set; } = new List<MatchEvent>();

        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
    }
}
