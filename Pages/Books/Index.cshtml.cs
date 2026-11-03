using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;
using Marincas_Bianca_Lab2.Data;

namespace Marincas_Bianca_Lab2.Pages.Books;

public class IndexModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;

    public IndexModel(Marincas_Bianca_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();
    }
}
