using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.CRUD
{
    class CategoryCRUD
    {
        public static void Create(string name, string slug)
        {
            using (var ctx = new BlogDataContext())
            {
                var category = new Category()
                {
                    Name = name,
                    Slug = slug
                };


                ctx.Categories.Add(category);

                ctx.SaveChanges();
            }
        }

        public static void Update(int id, string name, string slug)
        {
            using (var ctx = new BlogDataContext())
            {
                var category = ctx.Categories.FirstOrDefault(x => x.Id == id);

                category.Name = name;
                category.Slug = slug;

                ctx.Categories.Update(category);
                ctx.SaveChanges();
            }
        }

        public static void ReadAll()
        {
            using (var ctx = new BlogDataContext())
            {
                var categories = ctx.Categories.AsNoTracking();

                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id} Name: {category.Name} Slug {category.Slug}");
                }
            }
        }

        public static void ReadById(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var category = ctx.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);

                Console.WriteLine($"ID: {category.Id} Name: {category.Name} Slug {category.Slug}");
            }
        }

        public static Category GetById(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var category = ctx.Categories.FirstOrDefault(x => x.Id == id);

                return category;
            }
        }
    }
}