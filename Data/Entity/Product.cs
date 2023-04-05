namespace Data.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}