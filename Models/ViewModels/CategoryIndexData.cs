using Marincas_Bianca_Lab2.Models;

namespace Marincas_Bianca_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}