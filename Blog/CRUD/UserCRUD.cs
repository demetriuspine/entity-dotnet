using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.CRUD
{
    class UserCRUD
    {
        public static void Create()
        {
            using (var ctx = new BlogDataContext())
            {
                var user = new User()
                {
                    Name = "Albert Camus",
                    Slug = "albertcamus",
                    Email = "albert@camus.com",
                    Bio = "Absurd",
                    Image = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50?s=500",
                    PasswordHash = "205e460b479e2e5b48aec07710c08d50"
                };

                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }

        public static void Update(string name, string slug, int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == id);

                user.Name = name;

                user.Slug = slug;

                ctx.Users.Update(user);
                ctx.SaveChanges();
            }
        }

        public static void ReadAll()
        {
            using (var ctx = new BlogDataContext())
            {
                var users = ctx.Users.AsNoTracking();

                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id} Name: {user.Name} Slug {user.Slug}");
                }
            }
        }

        public static void ReadById(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var user = ctx.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);

                Console.WriteLine($"ID: {user.Id} Name: {user.Name} Slug {user.Slug}");

            }
        }

        public static User GetById(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == id);

                return user;

            }
        }
    }
}