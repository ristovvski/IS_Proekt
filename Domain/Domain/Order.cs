using IS_Proekt.Identity;

namespace IS_Proekt.Domain

{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public BookStoreApplicationUser Owner { get; set; }
        public IEnumerable<BookInOrder> BooksInOrder { get; set; }
    }
}
