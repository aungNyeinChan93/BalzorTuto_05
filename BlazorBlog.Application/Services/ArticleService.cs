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

        public async Task<Article?> GetArticleAsync(int id)
        {
            var article = await _articleRepositry.GetArticleAsync(id);
            return article;
        }

        public async Task<bool> CreatArticleAsync(Article article)
        {
            var isSuccess = await _articleRepositry.CreateArticleAsync(article);
            return isSuccess;
        }

        public async Task<bool> UpdateArticleAsync(int id, Article article)
        {
            var result = await _articleRepositry.UpdateArticleAsync(id, article);
            return result;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var result = await _articleRepositry.DeleteArticleAsync(id);
            return result;
        }
    }
}
