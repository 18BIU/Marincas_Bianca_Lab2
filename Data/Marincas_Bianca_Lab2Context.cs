using Microsoft.EntityFrameworkCore;
using Marincas_Bianca_Lab2.Models;

namespace Marincas_Bianca_Lab2.Data
{
    public class Marincas_Bianca_Lab2Context : DbContext
    {
        public Marincas_Bianca_Lab2Context(DbContextOptions<Marincas_Bianca_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
    }
}