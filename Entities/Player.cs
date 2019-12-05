using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Maximum of 25 characters")]
        [Display(Name = "First Name")]
        public string CharacterName { get; set; }

        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }

        [Required]
        [Range(1, 3)]
        public int FavorableStatId { get; set; } //1 = str, 2 = int, 3 = dex

        public bool IsDeleted { get; set; } // Check whether a player has been deleted
    }
}
