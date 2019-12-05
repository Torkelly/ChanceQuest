using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChanceQuest.Entities;
using ChanceQuest.Models.Player;

namespace ChanceQuest.Models
{
    public class CreatePlayerCommand : EditPlayer
    {
        public ChanceQuest.Entities.Player ToPlayer()
        {
            return new ChanceQuest.Entities.Player
            {
                CharacterName = CharacterName,
                PeasantHappiness = PeasantHappiness,
                NobleHappiness = NobleHappiness,
                RoyalHappiness = RoyalHappiness,
                FavorableStatId = FavorableStatId
            };
        }
    }
}
