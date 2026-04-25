using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorBlog.Server.Models;

namespace BlazorBlog.Server.Data
{
    public class AppDbContext2Context : DbContext
    {
        public AppDbContext2Context (DbContextOptions<AppDbContext2Context> options)
            : base(options)
        {
        }

        public DbSet<BlazorBlog.Server.Models.Category> Category { get; set; } = default!;
    }
}
