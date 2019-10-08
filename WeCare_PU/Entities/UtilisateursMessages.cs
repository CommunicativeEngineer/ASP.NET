using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeCare_PU.Entities
{
    [Table("UtilisateursMessages")]
    public class UtilisateursMessages
    {
        [Key]
        public int UtilisateursMessagesID { get; set; }

        public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public int MessagerieID { get; set; }
        public virtual Messagerie Message { get; set; }

    }
}
