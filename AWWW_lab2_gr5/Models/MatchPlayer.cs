namespace AWWW_lab2_gr5.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }

        // Foreign keys
        public int MatchId { get; set; }
        public int PositionId { get; set; }
        public int PlayerId { get; set; }

        // Navigation property
        public Match Match { get; set; }
        public Position Position { get; set; }
        public Player Player { get; set; }
        public IList<MatchEvent> MatchEvents { get; set; }
    }
}
