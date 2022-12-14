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



                var tags = ctx.Tags; // ainda não foi executado, é apenas uma referência

                foreach (var tag in tags) // aqui foi executado/chamado no banco
                {
                    Console.WriteLine($"ID: {tag.Id} Name: {tag.Name}");
                }

                // var firstTag = ctx.Tags.FirstOrDefault(x => x.Id == 1); // sempre que for atualizar, buscar direto do banco

                // firstTag.Name = ".NET";

                // firstTag.Slug = "dotnet";

                // ctx.Update(firstTag);
                // ctx.SaveChanges();


                // var secondTag = ctx.Tags.FirstOrDefault(x => x.Id == 2);

                // ctx.Remove(secondTag);
                // ctx.SaveChanges();

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine($"ID: {tag.Id} Name: {tag.Name}");
                // }

                // var filteredTags = ctx
                //     .Tags
                //     .ToList()                            // erro de performance, tras um SELECT * para a memória, se tiver muita coisa, vai travar
                //     .Where (x => x.Name.Contains("NET"));


                var filteredTags = ctx
                    .Tags
                    .Where(x => x.Name.Contains("NET"))
                    .ToList();

                foreach (var filteredTag in filteredTags) // aqui foi executado/chamado no banco
                {
                    Console.WriteLine($"ID: {filteredTag.Id} Name: {filteredTag.Name}");
                }
            }

        }
    }
}
