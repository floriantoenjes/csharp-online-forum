using System;
using System.Security.Claims;
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
        
        private readonly ThreadService _threadService;

        public BoardController(BoardService boardService, ThreadService threadService)
        {
            _boardService = boardService;
            _threadService = threadService;
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
        
        public IActionResult BoardDetail(int boardId, int page = 0, int limit = 25)
        {
            var board = _boardService.GetBoard(boardId);
            var threads = _threadService.GetThreadsByBoardId(boardId, page, limit);

            var boardDetailViewModel = new BoardDetailViewModel();
            boardDetailViewModel.Board = board;
            boardDetailViewModel.Threads = threads;
            boardDetailViewModel.Limit = limit;

            return View(boardDetailViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateThread(int boardId, BoardDetailViewModel boardDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                _boardService.CreateThread(boardId, boardDetailViewModel.Thread, boardDetailViewModel.Post, this.CurrentUserId());
                return RedirectToAction("Thread", "Thread", new { threadId = boardDetailViewModel.Thread.Id });
            }

            return RedirectToAction("BoardDetail", new { boardId });
        }
    }
}