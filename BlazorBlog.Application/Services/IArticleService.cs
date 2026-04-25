using BlazorBlog.Domain.Articles;

namespace BlazorBlog.Application.Services
{
    public interface IArticleService
    {
        Task<bool> CreatArticleAsync(Article article);
        Task<bool> DeleteArticleAsync(int id);
        Task<List<Article>?> GetAllArticleAsync();
        Task<Article?> GetArticleAsync();
        Task<bool> UpdateArticleAsync(int id, Article article);
    }
}