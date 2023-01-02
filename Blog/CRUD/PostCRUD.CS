using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.CRUD
{
    class PostCRUD
    {
        public static void NewStaticPost()
        {
            using (var ctx = new BlogDataContext())
            {
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

        public static void ReadAllByDescendingLastUpdate()
        {
            using (var ctx = new BlogDataContext())
            {
                var posts = ctx
                    .Posts
                    .AsNoTracking()
                    .Include(x => x.Author) // como se fosse um join
                    .Include(x => x.Category) // como se fosse um join
                    .OrderByDescending(x => x.LastUpdateDate)
                    .ToList();

                foreach (var post in posts)
                {
                    Console.WriteLine($"Autor: {post.Author?.Name} - Categoria: {post.Category?.Name} - Título: {post.Title}"); // por padrão, o EF não preenche os objetos, por isso Author e Category serão nulos
                }
            }
        }

        public static Post FindById(int authorId)
        {
            using (var ctx = new BlogDataContext())
            {
                var post = ctx
                    .Posts
                    .Include(x => x.Author) // como se fosse um join
                    .Include(x => x.Category) // como se fosse um join
                    .OrderByDescending(x => x.LastUpdateDate)
                    .FirstOrDefault(x => x.AuthorId == authorId);
                return post;
            }
        }

        public static void AlterNameByPost(Post post, string name)
        {
            using (var ctx = new BlogDataContext())
            {
                post.Author.Name = name;

                ctx.Posts.Update(post);
                ctx.SaveChanges();
            }
        }
    }
}
