using kuaforsalonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    [Table("Salon")]
    public class Salon
    {
        public Salon()
        {
            Calisanlar = new HashSet<Calisan>();
            Islemler = new HashSet<Islem>();
        }

        [Key]
        public int SalonId { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

        [Required]
        public string CalismaSaatleri { get; set; }

        public virtual ICollection<Calisan> Calisanlar { get; set; }
        public virtual ICollection<Islem> Islemler { get; set; }


    }
}
