
namespace AWWW_lab2_gr5.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public IList<Article> Aricles { get; set; }
    }
}
