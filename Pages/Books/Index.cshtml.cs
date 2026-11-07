using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marincas_Bianca_Lab2.Pages.Books;

public class IndexModel : PageModel
{
    private readonly Marincas_Bianca_Lab2Context _context;

    public IndexModel(Marincas_Bianca_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;
    public BookData BookD { get; set; } = default!;
    public int BookID { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id, int? categoryID)
    {
        BookD = new BookData();

        BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

        if (id != null)
        {
            BookID = id.Value;
            Book book = BookD.Books.Where(i => i.ID == id.Value).Single();
            BookD.Categories = book.BookCategories!.Select(s => s.Category);
        }
    }
}
