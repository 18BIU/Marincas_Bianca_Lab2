using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Marincas_Bianca_Lab2.Data;

namespace Marincas_Bianca_Lab2.Pages.Books;

public class CreateModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;

    public CreateModel(Marincas_Bianca_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public IActionResult OnGet()
    {
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

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    private void LoadLists()
    {
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

        var authorList = _context.Author.Select(a => new
        {
            a.ID,
            FullName = a.FirstName + " " + a.LastName
        });
        ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
    }
}