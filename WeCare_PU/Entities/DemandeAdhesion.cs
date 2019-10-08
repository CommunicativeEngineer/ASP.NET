using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("DemandeAdhesion")]
    public class DemandeAdhesion
    {
        [Key]
        public int DemandeAdhesionID { get; set; }

        [Display(Name = "Demande")]
        public Boolean Demande { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }

        //public virtual ICollection<DemandeAdhesionUtilisateur> Utilisateurs { get; set; }

        /*public int CitoyenID { get; set; }
        public virtual Citoyen Citoyen { get; set; }*/

        public int AssociationID { get; set; }
        public virtual Association Association { get; set; }
    }
}
