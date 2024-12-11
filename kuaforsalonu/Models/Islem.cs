using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    [Table("Islem")]
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }  // İşlem adı

        [Required]
        public int SureDakika { get; set; }  // İşlem süresi (dakika)

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ucret { get; set; }  // İşlem ücreti

        [ForeignKey("Salon")]
        public int SalonId { get; set; }  // Hangi salona ait olduğu

        public Salon Salon { get; set; } 
    }
}
