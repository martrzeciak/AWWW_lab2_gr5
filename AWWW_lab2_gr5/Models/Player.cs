using System.Runtime.InteropServices;

namespace AWWW_lab2_gr5.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }

        // Foreign keys
        public int TeamId { get; set; }
        public int PositionId { get; set; }

        // Navigation property
        public Team Team { get; set; }
        public List<Position> Positions { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
