using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ionescu_Andrei_Proiect.Data;
using Ionescu_Andrei_Proiect.Models;

namespace Ionescu_Andrei_Proiect.Pages.ProductSuppliers
{
    public class DeleteModel : PageModel
    {
        private readonly Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext _context;

        public DeleteModel(Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductSupplier = await _context.ProductSupplier.FindAsync(id);

            if (ProductSupplier != null)
            {
                _context.ProductSupplier.Remove(ProductSupplier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
