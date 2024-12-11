namespace kuaforsalonu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Yetki")]
    public partial class Yetki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yetki()
        {
            Musteris = new HashSet<Musteri>();
        }

        [Key]
        public int YetkiNo { get; set; }

        [Required]
        [StringLength(50)]
        public string YetkiAdı { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteris { get; set; }
    }
}
