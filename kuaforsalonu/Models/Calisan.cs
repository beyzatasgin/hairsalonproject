using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    public class Calisan
    {
        [Key]
        public int CalisanNo { get; set; }

        [Required]
        [StringLength(20)]
        public string Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(20)]
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
        [StringLength(11)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string Uzmanlik { get; set; }
        
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
       
    }
}
