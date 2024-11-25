using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wijitha_Book_Store.Data;

namespace Wijitha_Book_Store.Controllers
{
    public class StoreController : Controller
    {
        private readonly Wijitha_Book_StoreContext _context;

        public StoreController(Wijitha_Book_StoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Store/Index.cshtml", await _context.Book.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View("~/Views/Store/Details.cshtml", book);
           
        }
    }
    
}
