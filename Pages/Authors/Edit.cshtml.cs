using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marincas_Bianca_Lab2.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly Marincas_Bianca_Lab2Context _context;

        public EditModel(Marincas_Bianca_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(a => a.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            Author = author;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorToUpdate = await _context.Author.FirstOrDefaultAsync(a => a.ID == id);
            if (authorToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Author>(
                authorToUpdate,
                "Author",
                a => a.FirstName, a => a.LastName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}