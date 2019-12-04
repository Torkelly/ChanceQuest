using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models.Player
{
    public class PlayerDetails
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }
        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }
        public int FavorableStatId { get; set; }
        public DateTime LastModified { get; internal set; }
    }
}
