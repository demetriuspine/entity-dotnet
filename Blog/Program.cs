using System;
using Blog.CRUD;
using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // UserCRUD.Create();

            UserCRUD.ReadAll();
            UserCRUD.ReadById(4);

            // UserCRUD.Update("CAMUS, Albert", "camus", 4);

            // UserCRUD.ReadById(4);

            CategoryCRUD.ReadAll();
            CategoryCRUD.ReadById(4);

            // CategoryCRUD.Update(1, "Back-end", "backend");
            // CategoryCRUD.Update(3, "Front-end", "frontend");

            // CategoryCRUD.ReadById(1);
            // CategoryCRUD.ReadById(3);

            // CategoryCRUD.Create("Infra", "infra");

            var user = UserCRUD.GetById(4);
            var category = CategoryCRUD.GetById(4);

            Console.WriteLine(user.Name);
            Console.WriteLine(category.Slug);

            PostCRUD.Create(user, category);

        }
    }
}
