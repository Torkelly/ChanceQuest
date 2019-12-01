using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Chance Quest";
            return View();
        }
       
    }
}
