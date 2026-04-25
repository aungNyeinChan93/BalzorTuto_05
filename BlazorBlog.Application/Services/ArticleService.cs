using BlazorBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Application.Services
{
    public class ArticleService : IArticleService
    {
        public async Task<List<Article>?> GetAllArticleAsync()
        {
            return new List<Article>()
            {
                new Article{ArticleId = 1,Content="test content",Title = "test title"},
            };
        }

        public async Task<Article?> GetArticleAsync()
        {
            return default!;
        }

        public async Task<bool> CreatArticleAsync(Article article)
        {
            return default!;
        }

        public async Task<bool> UpdateArticleAsync(int id, Article article)
        {
            return default!;

        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            return default!;

        }
    }
}
