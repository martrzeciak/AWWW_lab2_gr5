namespace AWWW_lab2_gr5.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country{ get; set; }
        public string City { get; set; }
        public DateTime FundationDate { get; set; }

        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; } = new List<Match>();
        public virtual ICollection<Match> AwayMatches { get; set; } = new List<Match>();

        public virtual ICollection<Player> Players { get; set; } = new List<Player>(); 
    }
}
