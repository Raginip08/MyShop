using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core
{
    public class ProductCategoryViewModel
    {
        public Product product { get; set; }

        public IEnumerable<ProductCategory> productCategory { get; set; }
    }
}
