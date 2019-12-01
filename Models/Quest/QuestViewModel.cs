using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models.Quest
{
    public class QuestViewModel
    {
        public int Id { get; internal set; }
        public string Description { get; internal set; }
        public int HappyPlus { get; internal set; }
        public int HappyMinus { get; internal set; }
    }
}
