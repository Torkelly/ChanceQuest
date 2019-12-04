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
                    FavoriteStatId = p.FavorableStatId
                })
                .ToList();
        }
        public PlayerStateViewModel GetHappiness(int id)
        {
            return _context.Player
                .Where(p => p.Id == id)
                .Select(p => new PlayerStateViewModel
                {
                    Id = p.Id,
                    PeasantHappiness = p.PeasantHappiness,
                    NobleHappiness = p.NobleHappiness,
                    RoyalHappiness = p.RoyalHappiness
                })
                .SingleOrDefault();
        }

        public QuestViewModel GetNewQuest(int id)
        {
            return _context.Quests
                .Where(q => q.Id == id)
                .Select(q => new QuestViewModel
                {
                    Id = q.Id,
                    Description = q.Description,
                    HappyPlus = q.HappyPlus,
                    HappyMinus = q.HappyMinus,
                    FactionId = q.FactionId
                })
                .SingleOrDefault();
        }

        public WinQuest Win(int id)
        {
            return _context.Quests
                .Where(q => q.Id == id)
                .Select(q => new WinQuest
                {
                    //code here
                })
                .SingleOrDefault();
        }

        public LoseQuest Lose(int id)
        {
             return _context.Quests
                .Where(q => q.Id == id)
                .Select(q => new LoseQuest
                {
                    // code here
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

        /*public DeclineQuest Decline(int id)
        {
            return _context.Quests
               .Where(q => q.Id == id)
               .Select(q => new DeclineQuest
               {
                    // code here
               })
               .SingleOrDefault();
        }    */

        //plus

        public PeasantHappyPlus PPlus(int id, int plus)
        {
            return _context.Player
                .Where(p => p.Id == id)
                .Select(p => new PeasantHappyPlus
                {
                    PeasantHappiness = (p.PeasantHappiness + plus)
                })
                .SingleOrDefault();
        }

        public NobleHappyPlus NPlus(int id, int plus)
        {
             return _context.Player
                .Where(n => n.Id == id)
                .Select(n => new NobleHappyPlus
                {
                    NobleHappiness = (n.NobleHappiness + plus)
                })
                .SingleOrDefault();
        }

        public RoyalHappyPlus RPlus(int id, int plus)
        {
              return _context.Player
                .Where(r => r.Id == id)
                .Select(r => new RoyalHappyPlus
                {
                    RoyalHappiness = (r.RoyalHappiness + plus)
                })
                .SingleOrDefault();
        }

        //minus

        public PeasantHappyMinus PMinus(int id, int minus)
        {
             return _context.Player
                .Where(p => p.Id == id)
                .Select(p => new PeasantHappyMinus
                {
                    PeasantHappiness = (p.PeasantHappiness - minus)
                })
                .SingleOrDefault();
        }

        public NobleHappyMinus NMinus(int id, int minus)
        {
             return _context.Player
                .Where(p => p.Id == id)
                .Select(p => new NobleHappyMinus
                {
                    NobleHappiness = (p.NobleHappiness - minus)
                })
                .SingleOrDefault();
        }

        public RoyalHappyMinus RMinus(int id, int minus)
        {
             return _context.Player
                .Where(r => r.Id == id)
                .Select(r => new RoyalHappyMinus
                {
                    RoyalHappiness = (r.RoyalHappiness - minus)
                })
                .SingleOrDefault();
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
