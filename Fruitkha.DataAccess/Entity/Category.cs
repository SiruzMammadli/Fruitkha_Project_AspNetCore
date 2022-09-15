using System.ComponentModel.DataAnnotations;

namespace Fruitkha.DataAccess.Entity
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
