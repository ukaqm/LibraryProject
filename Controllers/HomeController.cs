using LibraryProject.Models;
using LibraryProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string bookGenre)
        {
            int pageSize = 10;

            var BookObject = new BookListViewModel
            {
                Books = _repo.Books
                     .Where(x => x.Classification == bookGenre || bookGenre == null)
                     .OrderBy(x => x.Title)
                     .Skip((pageNum - 1) * pageSize)
                     .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }

            };
            
            return View(BookObject);
        }
    }
}
