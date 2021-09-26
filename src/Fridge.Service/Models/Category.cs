using System.Collections.Generic;

namespace Fridge.Service.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
