using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_JDias.Models
{
    /// <summary>
    /// View model for the player
    /// </summary>
    public class PlayerViewModel : ViewModels
    {
        public int playerID { get; set; } = -1;

        [Required]
        [StringLength(100, ErrorMessage = "{0} is too long!")]
        [Display(Name = "Name")]
        public string name { get; set; }

        /// <summary>
        /// The players date of birth
        /// </summary>
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }

        /// <summary>
        /// The date of this record's creation (Defaults to current date of record's creation).
        /// </summary>
        [Required]
        [Display(Name = "Date of Record Creation")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime createDate { get; set; }
    }

    /// <summary>
    /// View model for the game stat
    /// </summary>
    public class PlayerGameStatViewModel :ViewModels
    {
        public int playerGameStatID { get; set; } = -1;

        /// <summary>
        /// The game that this stat refers to.
        /// </summary>
        [Required]
        [Display(Name = "Game")]
        public string gameName { get; set; }

        /// <summary>
        /// The player that this stat refers to.
        /// </summary>
        [Required]
        [Display(Name = "Player")]
        public string playerName { get; set; }

        /// <summary>
        /// Player's shots on goal during the game
        /// </summary>
        [Required]
        [Display(Name = "Shots on Goal")]
        public int shotsOnGoal { get; set; }

        /// <summary>
        /// The date of this record's creation (Defaults to current date of record's creation).
        /// </summary>
        [Required]
        [Display(Name = "Date of Record Creation")]
        public DateTime createDate { get; set; }
    }
}