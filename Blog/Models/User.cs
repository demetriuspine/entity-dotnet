using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] // not null
        [MinLength(3)] // mesmo não existindo essa condição no banco, ele dará erro se tentarmos salvar uma categoria com menos de 3 caracteres
        [MaxLength(80)]
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(200)]
        [Column("Email", TypeName = "NVARCHAR")]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Column("PasswordHash", TypeName = "VARCHAR")]
        public string PasswordHash { get; set; }
        [Required]
        [MinLength(3)]
        [Column("Bio", TypeName = "TEXT")]
        public string Bio { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(2000)]
        [Column("Image", TypeName = "VARCHAR")]
        public string Image { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}