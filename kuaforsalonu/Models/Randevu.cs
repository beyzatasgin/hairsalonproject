using kuaforsalonu.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        public int MusteriNo { get; set; }

        public int CalisanNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        public int SaatID { get; set; }

        // Navigation properties
        [ForeignKey("CalisanNo")]
        public virtual Calisan Calisan { get; set; }

        [ForeignKey("MusteriNo")]
        public virtual Musteri Musteri { get; set; }

        [ForeignKey("SaatID")]
        public virtual Saat Saat { get; set; }
    }
}
