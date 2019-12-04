using ChanceQuest.Data;
using ChanceQuest.Models;
using ChanceQuest.Models.Player;
using ChanceQuest.Models.Quest;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public PlayerStateViewModel GetHappiness(int id)
        {
            return _context.Players
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

        public DeclineQuest Decline(int id)
        {
            return _context.Quests
               .Where(q => q.Id == id)
               .Select(q => new DeclineQuest
               {
                    // code here
               })
               .SingleOrDefault();
        }

        //plus

        public PeasantHappyPlus PPlus(int id, int plus)
        {
            return _context.Players
                .Where(p => p.Id == id)
                .Select(p => new PeasantHappyPlus
                {
                    PeasantHappiness = (p.PeasantHappiness + plus)
                })
                .SingleOrDefault();
        }

        public NobleHappyPlus NPlus(int id, int plus)
        {
             return _context.Players
                .Where(n => n.Id == id)
                .Select(n => new NobleHappyPlus
                {
                    NobleHappiness = (n.NobleHappiness + plus)
                })
                .SingleOrDefault();
        }

        public RoyalHappyPlus RPlus(int id, int plus)
        {
              return _context.Players
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
             return _context.Players
                .Where(p => p.Id == id)
                .Select(p => new PeasantHappyMinus
                {
                    PeasantHappiness = (p.PeasantHappiness - minus)
                })
                .SingleOrDefault();
        }

        public NobleHappyMinus NMinus(int id, int minus)
        {
             return _context.Players
                .Where(p => p.Id == id)
                .Select(p => new NobleHappyMinus
                {
                    NobleHappiness = (p.NobleHappiness - minus)
                })
                .SingleOrDefault();
        }

        public RoyalHappyMinus RMinus(int id, int minus)
        {
             return _context.Players
                .Where(r => r.Id == id)
                .Select(r => new RoyalHappyMinus
                {
                    RoyalHappiness = (r.RoyalHappiness - minus)
                })
                .SingleOrDefault();
        }
    }
}
