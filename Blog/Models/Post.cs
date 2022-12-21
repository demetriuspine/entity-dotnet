using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Post")]
    class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CategoryId")] // por padrão, o EF vai dividir por maiúscula, sendo `Category` a classe e `Id` a propriedade, A classe Category deve estar mapeada, bem como a propriedade
        [Required] // not null
        [MinLength(3)] // mesmo não existindo essa condição no banco, ele dará erro se tentarmos salvar uma categoria com menos de 3 caracteres
        [MaxLength(80)]
        [Column("Name", TypeName = "NVARCHAR")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // fazendo isso, o EF já entende que é uma propriedade de navegação (ajuda a fazer joins)
        [ForeignKey("AuthorId")] // por padrão, o EF vai dividir por maiúscula, sendo `Author` a classe e `Id` a propriedade, A classe Author deve estar mapeada, bem como a propriedade
        public User Author { get; set; } // fazendo isso, o EF já entende que é uma propriedade de navegação (ajuda a fazer joins), e o EF já entende que Author é User
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}