using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Tag")] // data annotaions: são dependentes
    class Tag
    {
        [Key] // data annotaions: são dependentes
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}