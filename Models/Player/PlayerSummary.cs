using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Models.Player
{
    public class PlayerSummary
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int PeasantHappiness { get; set; }
        public int NobleHappiness { get; set; }
        public int RoyalHappiness { get; set; }
        public int FavoriteStatId { get; set; }

        public static PlayerSummary FromPlayer(PlayerSummary ps)
        {
            return new PlayerSummary
            {
                Id = ps.Id,
                CharacterName = ps.CharacterName,
                PeasantHappiness = ps.PeasantHappiness,
                NobleHappiness = ps.NobleHappiness,
                RoyalHappiness = ps.RoyalHappiness,

            };
        }
    }
}
