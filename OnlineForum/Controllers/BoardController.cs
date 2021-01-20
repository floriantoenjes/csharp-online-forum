using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class BoardController : Controller
    {
        private readonly BoardService _boardService;
        
        public BoardController(BoardService boardService)
        {
            _boardService = boardService;
            
        }
        
        public IActionResult BoardOverview()
        {
            ViewBag.Boards = _boardService.GetAllBoards();
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateBoard(Board board)
        {
            if (ModelState.IsValid)
            {
                _boardService.CreateBoard(board);
            }

            return RedirectToAction("BoardOverview");
        }
        
        public IActionResult BoardDetail(int boardId)
        {
            var board = _boardService.GetBoard(boardId);
            ViewBag.Board = board;

            return View();
        }

        [HttpPost]
        public IActionResult CreateThread(int boardId, Thread thread)
        {
            if (ModelState.IsValid)
            {
                _boardService.CreateThread(boardId, thread);
            }

            return RedirectToAction("BoardDetail", new { boardId });
        }
    }
}