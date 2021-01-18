using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BoardService _boardService;

        public HomeController(ILogger<HomeController> logger, BoardService boardService)
        {
            _logger = logger;
            _boardService = boardService;
        }

        public IActionResult Index()
        {
            ViewBag.Boards = _boardService.GetAllBoards();
            return View();
        }

        [HttpPost]
        public void Index(Board board)
        {
            _boardService.CreateBoard(board);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
