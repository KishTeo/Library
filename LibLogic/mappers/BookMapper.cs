using AutoMapper;
using LibDB.models;
using LibLogic.DTOs;

namespace LibLogic.mappers
{
    public class BookMapper : Profile 
    {
        public BookMapper() { CreateMap<Book, BookDTO>().ReverseMap(); }
    }
}
