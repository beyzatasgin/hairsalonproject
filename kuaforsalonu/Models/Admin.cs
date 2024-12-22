using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kuaforsalonu.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
    }

}