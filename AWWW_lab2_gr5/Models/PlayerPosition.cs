namespace AWWW_lab2_gr5.Models
{
    public class PlayerPosition
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;

        public int PositionId { get; set; } 
        public Position Position { get; set; } = null!;
    }
}
