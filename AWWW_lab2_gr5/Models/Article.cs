﻿using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AuthorId { get; set; } 
        public int CategoryId { get; set; }
        public int? MatchId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public Category Category { get; set; }
        public Match Match{ get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }
    }
}