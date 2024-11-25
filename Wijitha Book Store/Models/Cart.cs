using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Wijitha_Book_Store.Data;

namespace Wijitha_Book_Store.Models
{
    public class Cart
    {
        private readonly Wijitha_Book_StoreContext _context;

        public Cart(Wijitha_Book_StoreContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public static Cart GetCart(IServiceProvider services)
        {
            // Retrieve HttpContextAccessor
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            var session = httpContextAccessor?.HttpContext?.Session;

            if (session == null)
            {
                throw new InvalidOperationException("Session is not available. Ensure session middleware is configured.");
            }

            // Retrieve DbContext
            var context = services.GetRequiredService<Wijitha_Book_StoreContext>();

            // Generate or retrieve Cart ID
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();
            session.SetString("Id", cartId);

            return new Cart(context) { Id = cartId };
        }

        public CartItem GetCartItem(Book book)
        {
            return _context.CartItems.SingleOrDefault(ci => ci.Book.Id == book.Id && ci.CartId == Id);

        }
        public void AddToCart(Book book, int quantity)
        {
            var cartItem = GetCartItem(book);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Book = book,
                    Quantity = quantity,
                    CartId = Id
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;

            }

            _context.SaveChanges();

        }





        public List<CartItem> GetAllCartItems()
        {
            return CartItems ??
                   (CartItems = _context.CartItems
                       .Where(ci => ci.CartId == Id)
                       .Include(ci => ci.Book)
                       .ToList());
        }

        public int GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => ci.Book.Price * ci.Quantity)
                .Sum();
        }
    }
}
