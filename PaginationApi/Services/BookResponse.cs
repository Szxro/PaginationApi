using Dtos;
using Models;

namespace PaginationApi.Services
{
    public class BookResponse
    {
        public List<BookDTO>? Books { get; set; }

        public int Pages { get; set; }

        public int CurrentPages { get; set; }
    }
}
