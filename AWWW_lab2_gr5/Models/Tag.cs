﻿namespace AWWW_lab2_gr5.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<Article> Artciles { get; set; }
    }
}
