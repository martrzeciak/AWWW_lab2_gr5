namespace AWWW_lab2_gr5.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }

        // Foreign keys
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; } = new List<MatchEvent>();
    }
}
