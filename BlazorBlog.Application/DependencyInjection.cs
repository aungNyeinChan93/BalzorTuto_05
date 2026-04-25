using BlazorBlog.Application.Services;
using BlazorBlog.Domain.Repositries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IArticleService,ArticleService>();

            return service;
        }
    }
}
