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

        public async Task<Article?> GetArticleAsync(int id)
        {
            var article = await _context.Articles.AsNoTracking().FirstOrDefaultAsync(a => a.ArticleId == id);
            return article;
        }

        public async Task<bool> CreateArticleAsync(Article article)
        {
            if (article is null)
            {
                return false;
            }
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateArticleAsync(int id, Article article)
        {
            var existArticle = await _context.Articles.AsNoTracking().FirstOrDefaultAsync(a => a.ArticleId == id);
            if (existArticle is null)
            {
                return false;
            }
            existArticle.Title = article.Title;
            existArticle.Content = article.Content;
            existArticle.IsPublished = article.IsPublished;

            _context.Entry(existArticle).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var existArticle = await _context.Articles.AsNoTracking().FirstOrDefaultAsync(a => a.ArticleId == id);
            if (existArticle is null)
            {
                return false;
            }
            _context.Articles.Remove(existArticle);
            _context.Entry(existArticle).State = EntityState.Deleted;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
    }
}
