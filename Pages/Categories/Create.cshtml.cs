using Marincas_Bianca_Lab2.Data;
using Marincas_Bianca_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marincas_Bianca_Lab2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Marincas_Bianca_Lab2Context _context;
        public CreateModel(Marincas_Bianca_Lab2Context context) { _context = context; }

        public IActionResult OnGet() => Page();

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Category.BookCategories");
            if (!ModelState.IsValid) return Page();

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}