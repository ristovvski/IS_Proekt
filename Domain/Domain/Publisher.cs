namespace IS_Proekt.Domain

{
    public class Publisher : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
