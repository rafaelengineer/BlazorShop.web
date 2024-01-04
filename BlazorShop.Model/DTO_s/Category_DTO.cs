using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class Category_DTO
    {
        public int categoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IconCSS { get; set; } = string.Empty;
    }
}
