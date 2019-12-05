using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }

        public IEnumerable<Item> Quests { get; set; }
        public class Item
        {
            public int Id { get; set; }
            public int FavorableStatId { get; set; }
            public string Description { get; set; }
        }
    }
}
