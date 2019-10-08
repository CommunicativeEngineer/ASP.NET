using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
   // [Table("Citoyen")]
    public class Citoyen:Utilisateur
    {
        /*[Key]
        public int CitoyenID { get; set; }*/



        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Nom de l'association")]
        [MinLength(2, ErrorMessage = "If faut saisir 2 charactères au minimum")]
        public string Nom { get; set; }

        [Display(Name = "Prenom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Nom de l'association")]
        [MinLength(2, ErrorMessage = "If faut saisir 2 charactères au minimum")]
        public string Prenom { get; set; }

        

        public virtual ICollection<Publication> Publications { get; set; }

        public virtual ICollection<CitoyenEvenement> CitoyenEvenements { get; set; }

        public virtual ICollection<DemandeAdhesion> DemandeAdhesions { get; set; }

        //public virtual ICollection<CitoyenAssociation> CitoyenAssociations { get; set; }



    }
}
