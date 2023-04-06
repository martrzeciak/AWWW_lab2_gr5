namespace AWWW_lab2_gr5.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Minute { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int? MatchPlayerId { get; set; }
        public MatchPlayer? MatchPlayer { get; set; }

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}
