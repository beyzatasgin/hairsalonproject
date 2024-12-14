using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string Eposta { get; set; }  

        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string Sifre { get; set; }

        [Required]
        public string Yetki { get; set; }  
    }
}
