using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AWWW_lab2_gr5.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [DisplayName("Tag name")]
        public string Name { get; set; }

        public virtual ICollection<Article> Artciles { get; set; } = new List<Article>();
    }
}
