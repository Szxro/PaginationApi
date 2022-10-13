using AutoMapper;
using Dtos;
using Models;

namespace PaginationApi.Profiles
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
        }
    }
}
