namespace AWWW_lab2_gr5.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }

        // Foreign keys
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        // Navigatin properties
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public List<Article> Articles { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
