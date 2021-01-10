using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ionescu_Andrei_Proiect.Data;
using Ionescu_Andrei_Proiect.Models;

namespace Ionescu_Andrei_Proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext _context;

        public CreateModel(Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProductSupplierID"] = new SelectList(_context.Set<ProductSupplier>(), "ID", "ProductSupplierName");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateSpecificCategoryData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Product>(
            newProduct,
            "Product",
            i => i.ProductName, i => i.Description,
            i => i.Price, i => i.ExpirationDate, i => i.ProductSupplierID))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateSpecificCategoryData(_context, newProduct);
            return Page();
        }

    }
}
