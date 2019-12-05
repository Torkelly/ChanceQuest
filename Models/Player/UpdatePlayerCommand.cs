using ChanceQuest.Data;
using ChanceQuest.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ChanceQuest.Models.Player
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