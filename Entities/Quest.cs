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
        int _HappyPlus { get; set; } // the int that adds happiness to according faction
        public int HappyPlus
        {
            get
            {
                return this.HappyPlus;
            }
            set
            {
                this._HappyPlus = 20;
            }
        }
        int _HappyMinus { get; set; }// the int that subtracts happiness from remaining factions

        public int HappyMinus
        {
            get
            {
                return this.HappyMinus;
            }
            set
            {
                this._HappyMinus = 5;
            }
        }
        public int FactionId { get; set; } // 1 = Peasant, 2 = Noble, 3 = Royal
        public int FavorableStatId { get; set; } //1 = strengh, 2 = intelligence, 3 = dexterity
    }
}
