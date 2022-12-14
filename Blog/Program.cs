using System;
using System.Linq;
using Blog.CRUD;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PostCRUD.ReadAllByDescendingLastUpdate();

            var post = PostCRUD.FindById(3);

            PostCRUD.AlterNameByPost(post, "Franz Kafka");

            PostCRUD.ReadAllByDescendingLastUpdate();

        }
    }
}
