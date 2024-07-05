using LibLogic.DTOs;

namespace LibLogic.Interfaces
{
    public interface IBookRentalService
    {
        Task<IEnumerable<BookRentalDTO>> GetAll();
        Task<BookRentalDTO> StartRentAsync(int bookId, int userId, DateTime date);
        Task ReturnBookAsync(int bookrentalId, DateTime date);
    }
}
