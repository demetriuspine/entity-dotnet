using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // indica que a chave será gerada pelo banco
        public int Id { get; set; }

        [Required] // not null
        [MinLength(3)] // mesmo não existindo essa condição no banco, ele dará erro se tentarmos salvar uma categoria com menos de 3 caracteres
        [MaxLength(80)]
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [Required] // not null
        [MinLength(3)] // mesmo não existindo essa condição no banco, ele dará erro se tentarmos salvar uma categoria com menos de 3 caracteres
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}