using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var ctx = new BlogDataContext();

            var user = new User()
            {
                Name = "Lucas Pine",
                Slug = "lucaspine",
                Email = "mr.pine97@gmail.com",
                Bio = "Backend Developer at Sorte Online",
                Image = "https://cdn-icons-png.flaticon.com/512/147/147144.png",
                PasswordHash = "$2y$10$yaWt3Ot7IM1Ak7g8qa2feeSJ16OxWa2oNgV70GDms4ae2CmtidnrS"
            };

            var category = new Category()
            {
                Name = "Backend",
                Slug = "Backend"
            };

            var post = new Post()
            {
                Author = user,
                Category = category,
                Body = "<p>Hello World<p>",
                Slug = "comecando-com-ef-core",
                Summary = "Neste artigo, aprenderemos EF Core",
                Title = "Começando com EF Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            ctx.Posts.Add(post); // não preciso criar user nem category no banco primeiro para criar um post, basta referencia-los

            ctx.SaveChanges();
        }
    }
}
