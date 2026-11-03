using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marincas_Bianca_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Marincas_Bianca_Lab2Context _context;

        public IndexModel(Marincas_Bianca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
