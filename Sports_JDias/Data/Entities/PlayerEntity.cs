using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_JDias.Data.Entities
{
    public abstract class myEntities
    {

    }
    public class PlayerEntity : myEntities
    {
        [Key]
        public int playerID { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public DateTime dateOfBirth { get; set; }

        [Required]
        public DateTime createDate { get; set; }
    }
}