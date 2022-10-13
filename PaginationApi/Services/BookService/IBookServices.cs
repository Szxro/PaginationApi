using Dtos;
using Models;

namespace PaginationApi.Services.BookService
{
    public interface IBookServices
    {
        Task<ServiceResponse<BookResponse>> GetAllBooks(int page);
    }
}
