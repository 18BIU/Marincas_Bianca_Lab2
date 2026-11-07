using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marincas_Bianca_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Marincas_Bianca_Lab2Context _context;
        public IndexModel(Marincas_Bianca_Lab2Context context) { _context = context; }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}