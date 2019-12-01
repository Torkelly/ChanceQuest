using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models.Player
{
    public class PlayerStateViewModel
    {
        public int Id { get; internal set; }
        public int PeasantHappiness { get; internal set; }
        public int NobleHappiness { get; internal set; }
        public int RoyalHappiness { get; internal set; }
    }
}
