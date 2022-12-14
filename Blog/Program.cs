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

                // var firstTag = ctx.Tags.FirstOrDefault(x => x.Id == 1); // sempre que for atualizar, buscar direto do banco

                // firstTag.Name = ".NET";

                // firstTag.Slug = "dotnet";

                // ctx.Update(firstTag);
                // ctx.SaveChanges();


                var secondTag = ctx.Tags.FirstOrDefault(x => x.Id == 2);

                ctx.Remove(secondTag);
                ctx.SaveChanges();

                foreach (var tag in tags)
                {
                    Console.WriteLine($"ID: {tag.Id} Name: {tag.Name}");
                }

            }

        }
    }
}
