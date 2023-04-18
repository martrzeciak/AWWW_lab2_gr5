namespace AWWW_lab2_gr5.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Aricles { get; set; } = new List<Article>();
    }
}
