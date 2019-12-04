using ChanceQuest.Data;
using ChanceQuest.Entities;
using ChanceQuest.Models;
using ChanceQuest.Models.Game;
using ChanceQuest.Models.Player;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    //[ValidateAntiForgeryToken]
    public class GameController : Controller
    {
        private readonly GameService _service;
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> _playerService;
        private readonly IAuthorizationService _authService;
        private readonly ILogger<GameController> _logger;


        public GameController(
            GameService service,
            UserManager<IdentityUser> playerService,
            IAuthorizationService authService, ILogger<GameController> logger)
        {
            _service = service;
            _playerService = playerService;
            _authService = authService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play()
        {
            ViewData["Message"] = "Chance Quest";
            var models = _service.GetPlayer();

            if (models == null)
            {
                _logger.LogError("Error");
            }

            return View(models);
        }

        // essentially the "play" action. 
        // use on a button
        public IActionResult AttemptQuest(GameViewModel model) 
        {
            int id = int.Parse(User.Identity.GetUserId());
            UpdatePlayer(id); // gets the user id and calls update method

            Random rand = new Random(); //gets 3 ints between 1 - 15 to choose quest Id
            int result1 = rand.Next(1, 15);
            int result2 = rand.Next(1, 15);
            int result3 = rand.Next(1, 15);

            var quest1 = _service.GetNewQuest(result1); //gets new quests
            var quest2 = _service.GetNewQuest(result2);
            var quest3 = _service.GetNewQuest(result3);

            return View(model);
        }

        public void UpdatePlayer(int id)
        {
            var player = context.Player.Find(id);

            if (player == null)
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

            if(success == true)
            {
                if (faction == 1)
                {
                    _service.PeasantHappinessUpdate(id, pos);
                    _service.NobleHappinessUpdate(id, neg);
                    _service.RoyalHappinessUpdate(id, neg);
                    
                }
                else if (faction == 2)
                {
                    _service.PeasantHappinessUpdate(id, neg);
                    _service.NobleHappinessUpdate(id, pos);
                    _service.RoyalHappinessUpdate(id, neg);
                }
                else if (faction == 3)
                {
                    _service.PeasantHappinessUpdate(id, neg);
                    _service.NobleHappinessUpdate(id, neg);
                    _service.RoyalHappinessUpdate(id, pos);
                }
            } 
            else
            {
                _service.PeasantHappinessUpdate(id, neg);
                _service.NobleHappinessUpdate(id, neg);
                _service.RoyalHappinessUpdate(id, neg);
            }

            context.SaveChanges();
        }

        public IActionResult Win()
        {
            return View(new WinGameViewModel());
        }

        public IActionResult Lose()
        {
            return View(new LoseGameViewModel());
        }

        public IActionResult ViewPlayer(int id)
        {
            var model = _service.GetPlayerDetails(id);

            if (model == null)
            {
                _logger.LogError("{Id} not found.", id);
            }

            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View(new CreatePlayerCommand());
        }

        [HttpPost, Authorize]
        public IActionResult Create(CreatePlayerCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _service.CreatePlayer(command);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the person"
                    );
                _logger.LogWarning("{PersonId} could not be saved.");
            }
            return View(command);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = _service.GetPlayerForUpdate(id);
            if (model == null)
            {
                _logger.LogWarning("{PersonId} could not be edited.", id);
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdatePlayerCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdatePlayer(command);
                    return RedirectToAction(nameof(View), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the person"
                    );
                _logger.LogWarning("{PersonId} could not be edited.");
            }

            return View(command);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeletePlayer(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
