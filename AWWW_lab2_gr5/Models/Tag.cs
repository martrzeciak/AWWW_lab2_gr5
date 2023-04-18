namespace AWWW_lab2_gr5.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Artciles { get; set; } = new List<Article>();
    }
}
