using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("Utilisateur")]
    public abstract class Utilisateur
    {
        [Key]
        public int UtilisateurID { get; set; }

        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Login")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "If faut saisir 6 charactères au minimum")]
        public string Password { get; set; }

        [Display(Name = "Mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir l'adresse mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public virtual ICollection<UtilisateursMessages> UtilisateursMessages { get; set; }


       // public virtual ICollection<DemandeAdhesionUtilisateur> DemandeAdhesions { get; set; }

        //public virtual ICollection<Evenement> Evenements { get; set; }

       // public virtual ICollection<CitoyenEvenement> CitoyenEvenements { get; set; }
    }
}
