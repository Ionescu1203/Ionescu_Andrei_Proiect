using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ionescu_Andrei_Proiect.Data;
using Ionescu_Andrei_Proiect.Models;

namespace Ionescu_Andrei_Proiect.Pages.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext _context;

        public IndexModel(Ionescu_Andrei_Proiect.Data.Ionescu_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
