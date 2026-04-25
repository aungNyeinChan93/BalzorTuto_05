using BlazorBlog.Domain.Repositries;
using BlazorBlog.Infrastructure.Repositries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInferstructure(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            });

            service.AddScoped<IArticleRepositry,ArticleRepositry>();

            return service;
        }
    }
}
