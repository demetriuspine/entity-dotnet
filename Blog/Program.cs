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
                var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };

                ctx.Tags.Add(tag);

                ctx.SaveChanges(); // salva no banco



                // var tag = ctx.Tags.Where(x => x.Name == "ASP.NET").FirstOrDefault();

                // Console.WriteLine(tag.Name);

            }

        }
    }
}
