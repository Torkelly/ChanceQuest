using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Quest
    {
        public int Id { get; set; } // to differentiate quests
        public string Description { get; set; } // just text that describes what the quest entails
        public int HappyPlus { get; set; } // the int that adds happiness to according faction
        public int HappyMinus { get; set; } // the int that subtracts happiness from remaining factions
        public Faction FactionType { get; set; }
    }
}
