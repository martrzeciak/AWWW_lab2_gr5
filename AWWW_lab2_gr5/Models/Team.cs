namespace AWWW_lab2_gr5.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country{ get; set; }
        public string City { get; set; }
        public DateTime FundationDate { get; set; }

        // Foreign key
        public int LeagueId { get; set; }

        // Navigation properties
        public League League { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
        public List<Player> Players { get; set; }
    }
}
