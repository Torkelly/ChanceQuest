using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChanceQuest.Data;
using ChanceQuest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChanceQuest.Controllers
{
    public class PlayController : Controller
    {
        private readonly GameService _service;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _playerService;
        private readonly IAuthorizationService _authService;
        private readonly ILogger<PlayController> _logger;


        public PlayController(
            GameService service,
            UserManager<IdentityUser> playerService, ApplicationDbContext context,
            IAuthorizationService authService, ILogger<PlayController> logger)
        {
            _service = service;
            _playerService = playerService;
            _context = context;
            _authService = authService;
            _logger = logger;
        }
        public IActionResult Index(GameViewModel model) 
        {
            UpdatePlayer(model); // gets the user id and calls update method

            Random rand = new Random(); //gets 3 ints between 1 - 15 to choose quest Id
            int result1 = rand.Next(1, 15);
            int result2 = rand.Next(1, 15);
            int result3 = rand.Next(1, 15);

            var quest1 = _service.GetNewQuest(result1); //gets new quests
            var quest2 = _service.GetNewQuest(result2);
            var quest3 = _service.GetNewQuest(result3);

            return View(model);
        }
        public void UpdatePlayer(GameViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Error");
                throw new Exception("Unable to find player");
            }

            Random rand = new Random();
            int result = rand.Next(1, 100);
            int faction = rand.Next(1, 3);
            int pos, neg; bool success = false;

            if (result < 50)
            {
                pos = 0; //when player loses a quest - 50/50 chance
                neg = -5;
            }
            else //if result is 50+
            {
                pos = 20; //faction gets +20 happiness when quest succeeds
                neg = -5;
                success = true;
            }

            if (success == true)
            {
                if (faction == 1)
                {
                    _service.PeasantHappinessUpdate(model.Id, pos);
                    _service.NobleHappinessUpdate(model.Id, neg);
                    _service.RoyalHappinessUpdate(model.Id, neg);

                }
                else if (faction == 2)
                {
                    _service.PeasantHappinessUpdate(model.Id, neg);
                    _service.NobleHappinessUpdate(model.Id, pos);
                    _service.RoyalHappinessUpdate(model.Id, neg);
                }
                else if (faction == 3)
                {
                    _service.PeasantHappinessUpdate(model.Id, neg);
                    _service.NobleHappinessUpdate(model.Id, neg);
                    _service.RoyalHappinessUpdate(model.Id, pos);
                }
            }
            else
            {
                _service.PeasantHappinessUpdate(model.Id, neg);
                _service.NobleHappinessUpdate(model.Id, neg);
                _service.RoyalHappinessUpdate(model.Id, neg);
            }
        }
    }
}