using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Marincas_Bianca_Lab2.Data;

namespace Marincas_Bianca_Lab2.Pages.Books;

public class EditModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;

    public EditModel(Marincas_Bianca_Lab2Context context)
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

		var book = await _context.Book
			.Include(b => b.Publisher)
			.Include(b => b.Author)
			.FirstOrDefaultAsync(m => m.ID == id);
		if (book == null)
		{
			return NotFound();
		}

		Book = book;
		LoadLists();
		return Page();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			LoadLists();
			return Page();
		}

		_context.Attach(Book).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!BookExists(Book.ID))
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

	private void LoadLists()
	{
		ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName", Book?.PublisherID);

		var authorList = _context.Author.Select(a => new
		{
			a.ID,
			FullName = a.FirstName + " " + a.LastName
		});
		ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName", Book?.AuthorID);
	}

	private bool BookExists(int id)
	{
		return _context.Book.Any(e => e.ID == id);
	}
}