using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("Evenement")]
    public abstract class Evenement
    {
        [Key]
        public int EvenementID { get; set; }

        [Display(Name = "Titre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le titre de l'événement")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Titre { get; set; }

        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir la description de l'événement")]
        [MinLength(10, ErrorMessage = "If faut saisir 10 charactères au minimum")]
        public string Description { get; set; }

        public virtual ICollection<CitoyenEvenement> CitoyenEvenements { get; set; }

        //association!
        public int AssociationID { get; set; }
        public virtual Association Association { get; set; }
    }
}
