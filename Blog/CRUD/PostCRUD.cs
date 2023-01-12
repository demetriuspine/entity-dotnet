using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.CRUD
{
    class PostCRUD
    {
        public static void Create(User user, Category category)
        {
            using (var ctx = new BlogDataContext())
            {
                var post = new Post
                {
                    Author = user,
                    Category = category,
                    Body = "<p>loren ipsum<p>",
                    Slug = "comecando-com-docker",
                    Summary = "Neste artigo, aprenderemos Docker",
                    Title = "Começando com Docker",
                    CreateDate = DateTime.Now,
                    // LastUpdateDate = DateTime.Now // testando default do bd
                };

                ctx.Posts.Add(post);

                ctx.SaveChanges();
            }
        }

        public static void Update(string name, string slug, int id)
        {
            using (var ctx = new BlogDataContext())
            {

            }
        }

        public static void ReadAll()
        {
            using (var ctx = new BlogDataContext())
            {

            }
        }

        public static void ReadById(int id)
        {
            using (var ctx = new BlogDataContext())
            {

            }
        }
    }
}