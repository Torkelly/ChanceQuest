using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Faction
    {
        public int Id { get; set; } // this isn't going to be a real Id - it's 1, 2, or 3. So we can make IF statements. If (id == 1) then Happiness +5
        public string FactionName { get; set; }                         //(1)Peasant, (2)Noble, (3)Royal
        public int Happiness { get; set; }
    }
}
