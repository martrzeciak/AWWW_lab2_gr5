namespace AWWW_lab2_gr5.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Minute { get; set; }

        // Foreign keys
        public int MatchEventId { get; set; }
        public int? MatchPlayerId { get; set; }
        public int EventTypeId { get; set; }

        // Navigation properties
        public Match Match { get; set; }
        public MatchPlayer MatchPlayer { get; set; }
        public EventType EventType { get; set; }
    }
}
