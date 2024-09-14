using IS_Proekt.Identity;

namespace IS_Proekt.Domain

{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public BookStoreApplicationUser? Owner { get; set; }
        public virtual ICollection<BookInShoppingCart>? BooksInShoppingCarts { get; set; }
    }
}
