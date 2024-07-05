using AutoMapper;
using LibLogic.Interfaces;
using LibDB.models;
using LibDB.Interfaces;
using LibLogic.DTOs;

public class BookRentalService : IBookRentalService
{
    private readonly IRepository<BookRental> _BookRentalRepository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public BookRentalService(IRepository<BookRental> BookRentalRepository, IRepository<Book> bookRepository, IRepository<User> userRepository, IMapper mapper)
    {
        _BookRentalRepository = BookRentalRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookRentalDTO>> GetAll()
    {
        var BookRental = await _BookRentalRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookRentalDTO>>(BookRental);
    }

    public async Task<BookRentalDTO> StartRentAsync(int bookId, int userId, DateTime date)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        var user = await _userRepository.GetByIdAsync(userId);

        var rent = new BookRental
        {
            UserId = userId,
            BookId = bookId,
            dateCapture = date,
            Book = book,
            User = user
        };

        var createdRent = await _BookRentalRepository.AddAsync(rent);
        return _mapper.Map<BookRentalDTO>(createdRent);
    }

    public async Task ReturnBookAsync(int rentId, DateTime date)
    {
        var rent = await _BookRentalRepository.GetByIdAsync(rentId);
        rent.dateReturn = date;
        await _BookRentalRepository.UpdateAsync(rent);
    }
}