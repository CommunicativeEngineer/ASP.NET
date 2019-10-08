using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("Publication")]
    public class Publication
    {
        [Key]
        public int PublicationID { get; set; }

        [Display(Name = "Titre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le titre de la publication")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Titre { get; set; }

        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir la description de la publication")]
        [MinLength(10, ErrorMessage = "If faut saisir 10 charactères au minimum")]
        public string Description { get; set; }


        [Display(Name = "Date")]
        public string Date { get; set; }


        public int CitoyenID { get; set; }
        public virtual Citoyen Citoyen { get; set; }


    }
}
