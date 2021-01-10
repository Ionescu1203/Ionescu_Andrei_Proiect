using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ionescu_Andrei_Proiect.Models
{
    public class ProductSupplier
    {
        public int ID { get; set; }
        public string ProductSupplierName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
