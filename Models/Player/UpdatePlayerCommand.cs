using ChanceQuest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChanceQuest.Entities;
using ChanceQuest.Models.Player;

namespace ChanceQuest.Models
{
    public class UpdatePlayerCommand : EditPlayer
    {
        public int Id { get; set; }

        public void UpdatePlayer(ChanceQuest.Entities.Player player)
        {
            player.CharacterName = CharacterName;
            player.PeasantHappiness = PeasantHappiness;
            player.RoyalHappiness = RoyalHappiness;
            player.FavorableStatId = FavorableStatId;
        }
    }
}