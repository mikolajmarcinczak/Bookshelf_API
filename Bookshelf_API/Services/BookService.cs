using Bookshelf_API.DTO;
using Bookshelf_API.Models;

namespace Bookshelf_API.Services
{
    public class BookService : IBookService
    {
        private readonly BookshelfContext context;

        public BookService(BookshelfContext context)
        {
            this.context = context;
        }

        #region Methods

        public ResponseDTO Add(Book book)
        {
            try
            {
                context.Add(book);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed." };
            }

            return new ResponseDTO { Code = 200, Message = "Book added to database.", Status = "Success." };
        }

        public ResponseDTO Delete(int id)
        {
            try
            {
                context.Book.Remove(GetBookById(id));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed." };
            }

            return new ResponseDTO { Code = 200, Message = "Book successfully deleted from the database.", Status = "Success." };
        }

        public ResponseDTO<IList<BookDTO>> GetAllBooks()
        {
            if (context.Book.ToList().Count == 0)
            {
                return new ResponseDTO<IList<BookDTO>> { Code = 400, Message = "No books in the list", Status = "Failed" };
            }

            var bookList = new List<BookDTO>();

            foreach (var book in context.Book.ToList())
            {
                bookList.Add(new BookDTO
                {
                    Author = book.Author,
                    Description = book.Description,
                    ImagePath = book.ImagePath,
                    ReleaseDate = book.ReleaseDate.ToShortDateString(),
                    Tags = book.Tags,
                    Title = book.Title
                });
            }

            return new ResponseDTO<IList<BookDTO>> { Code = 200, Message = "Books successfully downloaded from the database.", Status = "Succcess.",  Result = bookList };
        }

        public ResponseDTO<IList<BookMinimalDTO>> GetAllBooksMin()
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<BookDTO> GetBook(int id)
        {
            Book book = new Book();

            try
            {
                book = GetBookById(id);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<BookDTO> { Code = 400, Message = ex.Message, Status = "Failed." };
            }

            return new ResponseDTO<BookDTO> { Code = 200, Message = $"Book with id {id} successfully downloaded from the database.", Status = "Success.", Result = new BookDTO
                {
                    Author = book.Author,
                    Description = book.Description,
                    ImagePath = book.ImagePath,
                    ReleaseDate = book.ReleaseDate.ToShortDateString(),
                    Tags = book.Tags,
                    Title = book.Title
                }
            };
        }

        public Book GetBookById(int id)
        {
            return context.Book.Where(x => x.Id == id).SingleOrDefault() ?? throw new NullReferenceException();
        }

        public ResponseDTO<BookMinimalDTO> GetBookMin(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO Update(Book book)
        {
            var dbBook = GetBookById(book.Id);
            dbBook.Author = book.Author;
            dbBook.Description = book.Description;
            dbBook.ImagePath = book.ImagePath;
            dbBook.ReleaseDate = book.ReleaseDate; 
            dbBook.Tags = book.Tags;
            dbBook.Title = book.Title;
            context.SaveChanges();
            return new ResponseDTO { Code = 200, Message = "Book updated in the database." };
        }

        #endregion
    }
}
