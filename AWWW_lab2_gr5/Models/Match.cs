namespace AWWW_lab2_gr5.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public IList<Article> Articles { get; set; }

        public IList<MatchEvent> MatchEvents { get; set; }

        public IList<MatchPlayer> MatchPlayers { get; set; }
    }
}
