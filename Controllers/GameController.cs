using ChanceQuest.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService _service;
        private readonly UserManager<Player> _playerService;
        private readonly IAuthorizationService _authService;
        private readonly ILogger<GameController> _logger;

        public GameController(
            GameService service,
            UserManager<Player> playerService,
            IAuthorizationService authService, ILogger<GameController> logger)
        {
            _service = service;
            _playerService = playerService;
            _authService = authService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var models = _service.GetHappiness(1);

            if (models == null)
            {
                _logger.LogError("Error");
            }

            return View(models);
        }


        public IActionResult Play()
        {
            ViewData["Message"] = "Chance Quest";
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Win()
        {
            return View();
        }

        public IActionResult Lose()
        {
            return View();
        }     
    }
}
