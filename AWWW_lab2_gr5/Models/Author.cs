using System.ComponentModel;

namespace AWWW_lab2_gr5.Models
{
    public class Author
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public IList<Article> Articles { get; set; } 
    }
}
