using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{

   // [Table("Association")]
    public class Association:Utilisateur
    {
       /* [Key]
        public int AssociationID { get; set; }*/

        

        [Display(Name = "NomAss")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Nom de l'association")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Nom { get; set; }

        [Display(Name = "Fondateur")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Fondateur de l'association")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Fondateur { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<Evenement> Evenements { get; set; }

        public virtual ICollection<DemandeAdhesion> DemandeAdhesions { get; set; }

        // public virtual ICollection<CitoyenAssociation> CitoyenAssociations { get; set; }



    }
}
