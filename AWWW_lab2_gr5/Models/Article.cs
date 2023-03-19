
namespace AWWW_lab2_gr5.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;

        // Foreign keys
        public int AuthorId { get; set; } 
        public int CategoryId { get; set; }
        public int? MatchId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public Category Category { get; set; }
        public Match Match{ get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
