using Microsoft.VisualBasic;

namespace AWWW_lab2_gr5.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public IList<MatchPlayer> MatchPlayers { get; set; }
        public List<PlayerPosition> PlayerPositions { get; }
    }
}
