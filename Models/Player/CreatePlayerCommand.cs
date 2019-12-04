﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChanceQuest.Entities;
using ChanceQuest.Models.Player;

namespace ChanceQuest.Entities
{
    public class CreatePlayerCommand : EditPlayer
    {
        public Player ToPlayer()
        {
            return new Player
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