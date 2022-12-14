using System;
using System.Linq;
using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var ctx = new BlogDataContext())
            {
                // var tag = new Tag { Name = "Node.js", Slug = "nodejs" };

                // ctx.Tags.Add(tag);

                // ctx.SaveChanges(); // salva no banco



                var tags = ctx.Tags;

                foreach (var tag in tags)
                {
                    Console.WriteLine($"ID: {tag.Id} Name: {tag.Name}");
                }

            }

        }
    }
}
