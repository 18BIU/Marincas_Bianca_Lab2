using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;
using Marincas_Bianca_Lab2.Data;

namespace Marincas_Bianca_Lab2.Pages.Borrowings;

public class DetailsModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;
    public DetailsModel(Marincas_Bianca_Lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
     .Include(b => b.Book)
         .ThenInclude(b => b.Author)
     .Include(b => b.Member)
     .FirstOrDefaultAsync(m => m.ID == id);

        return Page();
    }
}
