using BlazorBlog.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBlog.Domain.Articles
{
    public class Article : Entity 
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public DateTime RelaseDate { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = false;
    }
}
