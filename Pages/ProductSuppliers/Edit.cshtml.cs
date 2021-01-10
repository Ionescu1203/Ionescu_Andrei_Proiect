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

namespace Ionescu_Andrei_Proiect.Pages.ProductSuppliers
{
    public class EditModel : PageModel
    {
        private readonly Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext _context;

        public EditModel(Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductSupplier ProductSupplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductSupplier = await _context.ProductSupplier.FirstOrDefaultAsync(m => m.ID == id);

            if (ProductSupplier == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSupplierExists(ProductSupplier.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductSupplierExists(int id)
        {
            return _context.ProductSupplier.Any(e => e.ID == id);
        }
    }
}
