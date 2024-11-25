using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using Wijitha_Book_Store.Data;
using Wijitha_Book_Store.Models;

namespace Wijitha_Book_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly Wijitha_Book_StoreContext _context;
        private readonly Cart _cart;

        public CartController(Wijitha_Book_StoreContext context,Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }

        public IActionResult AddToCart(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null) {
                _cart.AddToCart(selectedBook, quantity: 1);
            }

            return RedirectToAction(actionName: "Index");
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
