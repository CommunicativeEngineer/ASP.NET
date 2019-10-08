using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("Administrateur")]
    public class Administrateur
    {
        [Key]
        public int AdministrateurID { get; set; }

        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Login")]
        [MinLength(4, ErrorMessage = "If faut saisir 4 charactères au minimum")]
        public string Login { get; set; }

        [Display(Name ="Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il faut saisir le Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "If faut saisir 6 charactères au minimum")]
        public string Password { get; set; }
    }
}
