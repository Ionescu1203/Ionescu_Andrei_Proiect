using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ionescu_Andrei_Proiect.Data;
using Ionescu_Andrei_Proiect.Models;

namespace Ionescu_Andrei_Proiect.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext _context;

        public EditModel(Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
 .Include(b => b.ProductSupplier)
 .Include(b => b.ProductCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);


            if (Product == null)
            {
                return NotFound();
            }
            PopulateSpecificCategoryData(_context, Product);
            ViewData["ProductSupplierID"] = new SelectList(_context.Set<ProductSupplier>(), "ID", "ProductSupplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product
            .Include(i => i.ProductSupplier)
            .Include(i => i.ProductCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(
            productToUpdate,
            "Product",
            i => i.ProductName, i => i.Description,
            i => i.Price, i => i.ExpirationDate, i => i.ProductSupplier))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateProductCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateSpecificCategoryData(_context, productToUpdate);
            return Page();
        }
    }

}
