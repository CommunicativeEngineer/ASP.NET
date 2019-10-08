using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("Messagerie")]
    public class Messagerie
    {
        [Key]
        public int MessagerieID { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public virtual ICollection<UtilisateursMessages> UtilisateursMessages { get; set; }

    }
}
