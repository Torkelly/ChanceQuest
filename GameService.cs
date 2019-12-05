using ChanceQuest.Data;
using ChanceQuest.Entities;
using ChanceQuest.Models;
using ChanceQuest.Models.Player;
using ChanceQuest.Models.Quest;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest
{
    public class GameService
    {
        readonly ApplicationDbContext _context;
        readonly ILogger _logger;

        public GameService(ApplicationDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<GameService>();
        }
        public ICollection<PlayerSummary> GetPlayer()
        {
            return _context.Player
                .Where(p => !p.IsDeleted)
                .Select(p => new PlayerSummary
                {
                    Id = p.Id,
                    CharacterName = p.CharacterName,
                    PeasantHappiness = p.PeasantHappiness,
                    NobleHappiness = p.NobleHappiness,
                    RoyalHappiness = p.RoyalHappiness,
                    FavorableStatId = p.FavorableStatId
                })
                .ToList();
        }

        public PlayerStateViewModel GetPlayerState(int id)
        {
            return _context.Player
                .Where(p => p.Id == id)
                .Select(p => new PlayerStateViewModel
                {
                    PeasantHappiness = p.PeasantHappiness,
                    NobleHappiness = p.NobleHappiness,
                    RoyalHappiness = p.RoyalHappiness
                })
                .SingleOrDefault();
        }

       /* public GameViewModel GetGameView()
        {
            return _context
        } */

        public QuestViewModel GetNewQuest(int id)
        {
            return _context.Quests
                .Where(q => q.Id == id)
                .Select(q => new QuestViewModel
                {
                    Id = q.Id,
                    Description = q.Description
                })
                .SingleOrDefault();
        }

        public bool DoesQuestExist(int id)
        {
            var quest = _context.Quests.Find(id);

            if (quest == null)
            {
                return false;
            }
            return !quest.IsDeleted;
        }

        //All add the int val, if you need to subtract happiness, use a negative int

        public void PeasantHappinessUpdate(int id, int val)
        {
            var player = _context.Player
                .Where(p => p.Id == id)
                .Select(p => new PeasantHappinessUpdateCommand
                {
                    PeasantHappiness = (p.PeasantHappiness + val)
                });
            _context.SaveChanges();
        }

        public void NobleHappinessUpdate(int id, int val)
        {
            var player = _context.Player
                .Where(n => n.Id == id)
                .Select(n => new NobleHappinessUpdateCommand
                {
                    NobleHappiness = (n.NobleHappiness + val)
                }); 
            _context.SaveChanges();
        }

        public void RoyalHappinessUpdate(int id, int val)
        {
            var player = _context.Player
              .Where(r => r.Id == id)
              .Select(r => new RoyalHappinessUpdateCommand
              {
                  RoyalHappiness = (r.RoyalHappiness + val)
              });
            _context.SaveChanges();
        }

        public int CreatePlayer(CreatePlayerCommand cmd)
        {
            var player = cmd.ToPlayer();
            _context.Add(player);
            _context.SaveChanges();
            return player.Id;
        }

        public void UpdatePlayer(UpdatePlayerCommand cmd)
        {
            var player = _context.Player.Find(cmd.Id);
            if (player == null) { throw new Exception("Unable to find the player"); }
            if (player.IsDeleted) { throw new Exception("Unable to update a deleted player"); }

            cmd.UpdatePlayer(player);
            _context.SaveChanges();
        }

        public UpdatePlayerCommand GetPlayerForUpdate(int Id)
        {
            return _context.Player
                .Where(x => x.Id == Id)
                .Where(x => !x.IsDeleted)
                .Select(x => new UpdatePlayerCommand
                {
                    CharacterName = x.CharacterName,
                    PeasantHappiness = x.PeasantHappiness,
                    RoyalHappiness = x.RoyalHappiness,
                    FavorableStatId = x.FavorableStatId,
                })
                .SingleOrDefault();
        }

        public PlayerDetails GetPlayerDetails(int id)
        {
            return _context.Player
                .Where(x => x.Id == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new PlayerDetails
                {
                    Id = x.Id,
                    CharacterName = x.CharacterName,
                    PeasantHappiness = x.PeasantHappiness,
                    NobleHappiness = x.NobleHappiness,
                    RoyalHappiness = x.RoyalHappiness,
                    FavorableStatId = x.FavorableStatId,
                })
                .SingleOrDefault();
        }

        public void DeletePlayer(int id)
        {
            var player = _context.Player.Find(id);
            if (player.IsDeleted) { throw new Exception("Unable to delete a deleted player"); }

            player.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
