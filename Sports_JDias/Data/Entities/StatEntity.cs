using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports_JDias.Data.Entities
{
    public class StatEntity : myEntities
    {
        [Key]
        public int playerGameStatID { get; set; }

        [Required]
        public int gameID { get; set; }

        [Required]
        public int playerID { get; set; }

        [Required]
        public int shotsOnGoal { get; set; }

        [Required]
        public DateTime createDate { get; set; }
    }
}