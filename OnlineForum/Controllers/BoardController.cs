using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;
using OnlineForum.ViewModels;

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
        [Authorize(Roles = "Admin")]
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
            
            var boardDetailViewModel = new BoardDetailViewModel();
            boardDetailViewModel.Board = board;

            return View(boardDetailViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateThread(int boardId, BoardDetailViewModel boardDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                _boardService.CreateThread(boardId, boardDetailViewModel.Thread, boardDetailViewModel.Post);
                return RedirectToAction("Thread", "Thread", new { threadId = boardDetailViewModel.Thread.Id });

            }

            return RedirectToAction("BoardDetail", new { boardId });
        }
    }
}