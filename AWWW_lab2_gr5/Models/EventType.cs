namespace AWWW_lab2_gr5.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<MatchEvent> MatchEvents{ get; set; }
    }
}
