using BlazorBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Domain.Repositries
{
    public interface IArticleRepositry
    {
        Task<List<Article>?> GetAllArticleAsync();
    }
}

