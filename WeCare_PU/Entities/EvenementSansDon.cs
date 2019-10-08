using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
   // [Table("EvenementSansDon")]
    public class EvenementSansDon:Evenement
    {
        [Required]
        [Display(Name = "Lieu")]
        public string Lieu { get; set; }
    }
}
