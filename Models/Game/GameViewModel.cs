using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models
{
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }

        public IEnumerable<QuestViewModel> Quests { get; set; }
        public class QuestViewModel
        {
            public int Id { get; set; }
            public int FavorableStat { get; set; }
            public string Description { get; set; }
        }
    }
}
