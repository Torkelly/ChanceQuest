using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Quest
    {
        [Key]
        public int Id { get; set; } // to differentiate quests
        public string Description { get; set; } // just text that describes what the quest entails
        public bool IsDeleted { get; set; } // Check whether a Quest has been deleted
    }
}
