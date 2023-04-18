namespace AWWW_lab2_gr5.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Minute { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int? MatchPlayerId { get; set; }
        public virtual MatchPlayer? MatchPlayer { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
