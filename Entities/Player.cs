using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Entities
{
    public class Player
    {
        int _Id { get; set; }
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                this._Id = 1;
            }
        }
        public int PeasantHappiness { get; set; }  // all of these just keeps the numbers deciding if you win/lose. 0 == dead, 100 == win
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }
    }
}
