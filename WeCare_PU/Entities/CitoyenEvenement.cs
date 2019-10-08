using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("CitoyenEvenement")]
    public class CitoyenEvenement
    {
        [Key]
        public int CitoyenEvenementID { get; set; }

        public int EvenementID { get; set; }
        public virtual Evenement Evenement { get; set; }

        public int CitoyenID { get; set; }
        public virtual Citoyen Citoyen { get; set; }

    }
}
