using BlazorBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Infrastructure
{
    public class AppDbContext :DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }

        public DbSet<Article> Articles { get; set; }
    }
}
