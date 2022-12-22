using System;
using Blog.Data;
using Blog.Models;

namespace Blog.CRUD
{
    class PostCRUD
    {
        public static void NewPost()
        {
            using var ctx = new BlogDataContext();

            var user = new User()
            {
                Name = "Milan Kundera",
                Slug = "milankundera",
                Email = "milan@kundera.com",
                Bio = "Writer",
                Image = "https://cdn-icons-png.flaticon.com/512/147/147144.png",
                PasswordHash = "$2y$10$yaWt3Ot7IM1Ak7g8qa2feeSJ16OxWa2oNgV70GDms4ae2CmtidnrS"
            };

            var category = new Category()
            {
                Name = "Frontend",
                Slug = "frontend"
            };

            var post = new Post()
            {
                Author = user,
                Category = category,
                Body = "<p>Hello World<p>",
                Slug = "comecando-com-html",
                Summary = "Neste artigo, aprenderemos HTML",
                Title = "Começando com HTML",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            ctx.Posts.Add(post); // não preciso criar user nem category no banco primeiro para criar um post, basta referencia-los

            ctx.SaveChanges();
        }
    }
}
