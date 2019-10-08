using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
   // [Table("EvenementAvecDon")]
    public class EvenementAvecDon:Evenement
    {
        [Required]
        [Display(Name = "Montant")]
        public double Montant { get; set; }
    }
}
