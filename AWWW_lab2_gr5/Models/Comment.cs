
namespace AWWW_lab2_gr5.Models
{
    public class Comment
    {
        // Primary key
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Foreign key
        public int ArticleId { get; set; }

        // Navigation property
        public Article Article { get; set; }
    }
}
