using kuaforsalonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kuaforsalonu.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefon { get; set; }

        public int YetkiNo { get; set; }

        public virtual Yetki Yetki { get; set; }

        public virtual ICollection<Randevu> Randevular{ get; set; }
    }
}
