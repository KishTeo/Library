using LibDB.Interfaces;
using LibDB.models;
using LibLogic.DTOs;
using AutoMapper;
using LibLogic.Interfaces;

namespace LibLogic.service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync( x =>  x.BookRental);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            var addedBook = await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDTO>(addedBook);
        }

        public async Task DeleteBookAsync(int bookId)
        {
            await _bookRepository.DeleteAsync(bookId);
        }

        public async Task UpdateBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task OffsBookAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book != null)
            {
                book.OffsDate = DateTime.Now;
                await _bookRepository.UpdateAsync(book);
            }
        }
    }
}
