using Bookshelf_API.DTO;
using Bookshelf_API.Models;

namespace Bookshelf_API.Services
{
    public interface IBookService
    {
        ResponseDTO Add(Book book);
        ResponseDTO Update(Book book);
        ResponseDTO Delete(int id);
        ResponseDTO<BookDTO> GetBook(int id);
        ResponseDTO<IList<BookDTO>> GetAllBooks();
        ResponseDTO<BookMinimalDTO> GetBookMin(int id);
        ResponseDTO<IList<BookMinimalDTO>> GetAllBooksMin();
        Book GetBookById(int id);
    }
}
