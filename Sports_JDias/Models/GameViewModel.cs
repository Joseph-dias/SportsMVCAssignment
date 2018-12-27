using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_JDias.Models
{
    public class GameViewModel : ViewModels
    {
        public int gameID { get; set; } = -1;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} is too long!")]
        [Display(Name = "Name")]
        public string name { get; set; }

        /// <summary>
        /// Date of the game itself.
        /// </summary>
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime gameDate { get; set; }

        /// <summary>
        /// The date of this record's creation (Defaults to current date of record's creation).
        /// </summary>
        [Required]
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime createDate { get; set; }
    }
}