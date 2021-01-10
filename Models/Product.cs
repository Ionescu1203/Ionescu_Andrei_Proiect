using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ionescu_Andrei_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required, StringLength(200, MinimumLength = 3)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Range(1, 200)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
       [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public int ProductSupplierID { get; set; }
        public ProductSupplier ProductSupplier { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
