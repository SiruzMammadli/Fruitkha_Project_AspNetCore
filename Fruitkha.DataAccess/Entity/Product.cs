using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fruitkha.DataAccess.Entity
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal Quantity { get; set; }
        [MaxLength(400)]
        public string? ImageUrl { get; set; }
        [DefaultValue(true)]
        public bool IsStock { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
