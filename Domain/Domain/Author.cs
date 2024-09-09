using System.ComponentModel.DataAnnotations.Schema;

namespace IS_Proekt.Domain
{
    public class Author : BaseEntity
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
