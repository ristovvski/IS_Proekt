using IS_Proekt.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IS_Proekt.Identity
{
    public class BookStoreApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
