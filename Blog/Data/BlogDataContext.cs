using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    class BlogDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}