using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.CRUD
{
    class TagCRUD
    {
        public static void Create(string name, string slug)
        {
            using (var ctx = new BlogDataContext())
            {
                var tag = new Tag { Name = name, Slug = slug };

                ctx.Tags.Add(tag);

                ctx.SaveChanges(); // salva no banco
            }
        }

        public static void ReadAll()
        {
            using (var ctx = new BlogDataContext())
            {
                var tags = ctx.Tags; // ainda não foi executado, é apenas uma referência

                foreach (var tag in tags) // aqui foi executado/chamado no banco
                {
                    Console.WriteLine($"ID: {tag.Id} Name: {tag.Name}");
                }
            }
        }

        public static void Update(string name, string slug, int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var tag = ctx.Tags.FirstOrDefault(x => x.Id == id); // sempre que for atualizar, buscar direto do banco

                tag.Name = name;

                tag.Slug = slug;

                ctx.Update(tag);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var secondTag = ctx.Tags.FirstOrDefault(x => x.Id == id);

                ctx.Remove(secondTag);
                ctx.SaveChanges();
            }
        }

        public static void ReadByNameContains(string nameFraction)
        {
            using (var ctx = new BlogDataContext())
            {
                // var filteredTags = ctx
                //     .Tags
                //     .ToList()                            // erro de performance, tras um SELECT * para a memória, se tiver muita coisa, vai travar
                //     .Where (x => x.Name.Contains(nameFraction));


                var filteredTags = ctx
                    .Tags
                    .Where(x => x.Name.Contains(nameFraction))
                    .AsNoTracking() // não faz tracking (não salva na memória), apenas usar quando não for usar update/delete, ganho de performance
                    .ToList();

                foreach (var filteredTag in filteredTags)
                {
                    Console.WriteLine($"ID: {filteredTag.Id} Name: {filteredTag.Name}");
                }
            }
        }

        public static void ReadById(int id)
        {
            using (var ctx = new BlogDataContext())
            {
                var tags = ctx.Tags; // ainda não foi executado, é apenas uma referência

                var firstOrDefaultTag = tags.AsNoTracking().FirstOrDefault(x => x.Id == id);
                var singleOrDefaultTag = tags.AsNoTracking().SingleOrDefault(x => x.Id == id);  // se tiver mais do que um, dá erro
                var nonexistentTag = tags.AsNoTracking().FirstOrDefault(x => x.Id == 494875101);

                Console.WriteLine(nonexistentTag?.Name); // vai dar null pq não existe
                Console.WriteLine(firstOrDefaultTag?.Name);
                Console.WriteLine(nonexistentTag?.Name);
            }
        }
    }
}