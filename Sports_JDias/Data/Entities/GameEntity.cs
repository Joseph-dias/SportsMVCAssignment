using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_JDias.Data.Entities
{
    public class GameEntity : myEntities
    {
        [Key]
        public int gameID { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        public DateTime gameDate { get; set; }

        [Required]
        public DateTime createDate { get; set; }
    }
}