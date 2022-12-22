using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Tag")] // data annotaions: são dependentes
    class Tag
    {
        [Key] // data annotaions: são dependentes
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // indica que a chave será gerada pelo banco
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Name", TypeName = "VARCHAR")]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}