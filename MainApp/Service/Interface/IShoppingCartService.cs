using IS_Proekt.Domain;
using IS_Proekt.DTO;
using System;

namespace Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCartInfo(string userId);
        bool AddBookToShoppingCart(BookInShoppingCart model, string userId);
        bool RemoveBookFromShoppingCart(Guid bookId, string userId);
        bool ConfirmOrder(string userId);
    }
}
