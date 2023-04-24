using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr5.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreationTime { get; set; } = DateTime.Now;
  
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? MatchId { get; set; }
        public virtual Match Match { get; set; }


        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
