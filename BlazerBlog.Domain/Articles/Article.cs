using BlazorBlog.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Domain.Articles
{
    public class Article : Entity 
    {
        public int ArticleId { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public DateTime RelaseDate { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = false;
    }
}
