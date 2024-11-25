using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wijitha_Book_Store.Models;

namespace Wijitha_Book_Store.Data
{
    public class Wijitha_Book_StoreContext : DbContext
    {
        public Wijitha_Book_StoreContext (DbContextOptions<Wijitha_Book_StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Wijitha_Book_Store.Models.Book> Book { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; }  


    }
}
