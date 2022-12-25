using System.ComponentModel.DataAnnotations;

namespace Bookshelf_API.Models
{
    public class Book
    {
        private int _id;
        private string _author;
        private string _title;
        private string _description;
        private string[] _tags;
        private string _imagePath;
        private DateTime _releaseDate;

        [Required]
        public int Id 
        { 
            get { return _id; } 
        }
        [Required]
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        [Required]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string[] Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
        [DataType(DataType.ImageUrl)]
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }
    }
}