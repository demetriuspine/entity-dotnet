using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; } // não tem chave primária, é composta, é necessário fazer uma outra configuração pois o EF não deixa
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; } // não tem chave primária, é composta, é necessário fazer uma outra configuração pois o EF não deixa

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}