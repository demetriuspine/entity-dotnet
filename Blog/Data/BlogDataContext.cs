using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } // como aqui está `Categories`, é preciso de dataAnnotation indicando que a coluna se chama Category
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine); // loga as queries no console
        }
    }
}