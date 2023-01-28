namespace Bookshelf_API.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public string[] Tags { get; set; }
    }
}
