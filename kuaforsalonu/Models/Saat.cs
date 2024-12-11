using kuaforsalonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsalonu.Models
{
    [Table("Saat")]
    public class Saat
    {
        public Saat()
        {
            Randevus = new HashSet<Randevu>();
        }

        [Key]
        public int SaatID { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        // Navigation property
        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}
