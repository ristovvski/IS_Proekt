using IS_Proekt.Domain;

namespace IS_Proekt.DTO
{
    public class ShoppingCartDto
    {
        public List<BookInShoppingCart> Books { get; set; }
        public decimal TotalPrice { get; set; }

        public ShoppingCartDto()
        {
            Books = new List<BookInShoppingCart>();
        }
    }
}
