
namespace AWWW_lab2_gr5.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<MatchPlayer> MatchPlayers { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
