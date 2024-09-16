using Domain.PetStore;
using IS_Proekt.Domain;
using IS_Proekt.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<BookStoreApplicationUser>
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<BookInShoppingCart> BooksInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<BookInOrder> BooksInOrders { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
    public class PetStoreDbContext : DbContext
    {
        public DbSet<Pet> Pet { get; set; }
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options)
           : base(options)
        {
        }
    }
}
