
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWWW_lab2_gr5.Models
{
    public class Author
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property
        public List<Article> Articles { get; set; } 
    }
}
