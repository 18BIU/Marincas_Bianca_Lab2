using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;
using Marincas_Bianca_Lab2.Data;
using Microsoft.AspNetCore.Authorization;

namespace Marincas_Bianca_Lab2.Pages.Books;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;

    public DeleteModel(Marincas_Bianca_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
        if (book is null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

		var book = await _context.Book
	.Include(b => b.Publisher)
	.Include(b => b.Author)
	.FirstOrDefaultAsync(m => m.ID == id);
		if (book != null)
        {
            Book = book;
            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
