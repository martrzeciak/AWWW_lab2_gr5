using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr5.Models
{
    public class Player
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Country { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!;

        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
    }
}
