using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Repositries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Application.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepositry _articleRepositry;

        public ArticleService(IArticleRepositry articleRepositry)
        {
            this._articleRepositry = articleRepositry;
        }

        public async Task<List<Article>?> GetAllArticleAsync()
        {
            var articles = await _articleRepositry.GetAllArticleAsync();
            return articles;
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
