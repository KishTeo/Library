using AutoMapper;
using LibDB.models;
using LibLogic.DTOs;

namespace LibLogic.mappers
{
    internal class BookRentalMapper : Profile
    {
        public BookRentalMapper() { CreateMap<BookRental, BookRentalDTO>().ReverseMap(); }
    }
}
