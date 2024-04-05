using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Components
{
    public class BookGenresViewComponent : ViewComponent
    {
        private IBookRepository _bookRepo;
        public BookGenresViewComponent(IBookRepository temp) 
        {
            _bookRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            var bookGenres = _bookRepo.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x);
            return View(bookGenres);
        }

    }
}
