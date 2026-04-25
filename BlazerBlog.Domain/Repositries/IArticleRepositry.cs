using BlazorBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Domain.Repositries
{
    public interface IArticleRepositry
    {
        Task<bool> CreateArticleAsync(Article article);
        Task<bool> DeleteArticleAsync(int id);
        Task<List<Article>?> GetAllArticleAsync();
        Task<Article?> GetArticleAsync(int id);
        Task<bool> UpdateArticleAsync(int id, Article article);
    }
}

