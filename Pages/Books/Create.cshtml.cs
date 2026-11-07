using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Marincas_Bianca_Lab2.Pages.Books;

public class CreateModel : BookCategoriesPageModel
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
        PopulateAssignedCategoryData(_context, new Book { BookCategories = new List<BookCategory>() });
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        if (!ModelState.IsValid)
        {
            LoadLists();
            PopulateAssignedCategoryData(_context, new Book { BookCategories = new List<BookCategory>() });
            return Page();
        }

        Book.BookCategories = new List<BookCategory>();
        if (selectedCategories != null)
        {
            foreach (var cat in selectedCategories)
            {
                Book.BookCategories.Add(new BookCategory { CategoryID = int.Parse(cat) });
            }
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    private void LoadLists()
    {
        var authorList = _context.Author.Select(x => new
        {
            x.ID,
            FullName = x.LastName + " " + x.FirstName
        });
        ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
        ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
    }
}