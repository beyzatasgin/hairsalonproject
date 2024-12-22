namespace kuaforsalonu.Models
{
    using kuaforsalonu.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Yetki")]
    public partial class Yetki
    {
        public Yetki()
        {
            Musteriler = new HashSet<Musteri>();
        }

        [Key]
        public int YetkiNo { get; set; }

        [Required]
        [StringLength(50)]
        public string YetkiAdı { get; set; }

        public virtual ICollection<Musteri> Musteriler { get; set; }
    }
}
