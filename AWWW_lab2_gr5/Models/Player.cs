using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr5.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public List<PlayerPosition> PlayerPosition { get; } = new();

        public IList<MatchPlayer> MatchPlayers { get; set; }
    }
}
