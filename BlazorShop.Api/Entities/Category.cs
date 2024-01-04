using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string IconCSS { get; set; } = string.Empty;

        public Collection<Product> Products { get; set; }
                         = new  Collection<Product>();

    }
}
