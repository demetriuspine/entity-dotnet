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
        public int CategoryId { get; set; }
        public Category Category { get; set; } // fazendo isso, o EF já entende que é uma propriedade de navegação (ajuda a fazer joins)
        [ForeignKey("AuthorId")] // por padrão, o EF vai dividir por maiúscula, sendo `Author` a classe e `Id` a propriedade, A classe Author deve estar mapeada, bem como a propriedade
        public int AuthorId { get; set; }
        public User Author { get; set; } // fazendo isso, o EF já entende que é uma propriedade de navegação (ajuda a fazer joins), e o EF já entende que Author é User
        [Required]
        [MinLength(3)]
        [MaxLength(170)]
        [Column("Title", TypeName = "VARCHAR")]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Column("Summary", TypeName = "VARCHAR")]
        public string Summary { get; set; }
        [Required]
        [Column("Body", TypeName = "TEXT")]
        public string Body { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
        [Required]
        [Column("CreateDate", TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }
        [Required]
        [Column("LastUpdateDate", TypeName = "DATETIME")]
        public DateTime LastUpdateDate { get; set; }
    }
}