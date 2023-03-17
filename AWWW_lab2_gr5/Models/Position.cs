namespace AWWW_lab2_gr5.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public List<MatchPlayer> MatchPlayers { get; set; }
        public List<Player> PlayersOneToManyRelationship { get; set; }
        public List<Player> PlayersManyToManyRelationship { get; set; }
    }
}
