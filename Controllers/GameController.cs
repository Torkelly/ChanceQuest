﻿using ChanceQuest.Entities;
using ChanceQuest.Models.Player;
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
    [ValidateAntiForgeryToken]
    public class GameController : Controller
    {
        private readonly GameService _service;
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
        public IActionResult View(int id)
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
