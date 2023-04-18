
namespace AWWW_lab2_gr5.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
