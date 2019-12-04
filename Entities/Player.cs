using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Player
    {
        public int Id { get; set; }
        
        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }
        public int FavorableStatId { get; set; } //1 = str, 2 = int, 3 = dex
    }
}
