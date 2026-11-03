namespace Marincas_Bianca_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; } = string.Empty;
        public string Adress { get; set; }
        public ICollection<Book>? Books { get; set; } 
    }
}
