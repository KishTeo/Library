using LibLogic.DTOs;

namespace LibLogic.Interfaces
{
    public interface IBookService
    {
        Task<BookDTO> AddBookAsync(BookDTO bookDTO);
        Task DeleteBookAsync(int bookId);
        Task UpdateBookAsync(BookDTO bookDTO);
        Task OffsBookAsync(int bookId);
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int bookId);
    }
}
