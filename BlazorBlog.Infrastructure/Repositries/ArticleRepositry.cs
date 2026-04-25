using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Repositries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Infrastructure.Repositries
{
    public class ArticleRepositry : IArticleRepositry
    {
        private readonly AppDbContext _context;

        public ArticleRepositry(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>?> GetAllArticleAsync()
        {
            var articles = await _context.Articles.AsNoTracking().ToListAsync();
            return articles;
        }
    }
}
