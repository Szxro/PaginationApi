using AutoMapper;
using Data;
using Dtos;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PaginationApi.Services.BookService
{
    public class BookServices : IBookServices
    {
        private readonly PaginationContext _context;
        private readonly IMapper _mapper;
        public BookServices(PaginationContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<ServiceResponse<BookResponse>> GetAllBooks(int page)
        {
            //Some Verification
            if (_context.Books == null)
                return new ServiceResponse<BookResponse>() { Message = "Data not Found", Success = false };
            if (page <= 0)
                return new ServiceResponse<BookResponse>() { Message = "The page have to be bigger", Success = false };
            try
            {
                //How many books you want to see
                var pageResults = 5f;
                //The Page Counts
                var pageCount = Math.Ceiling(_context.Books.Count() / pageResults);
                //Getting The book and mapping it into the DTO and making the pagination
                var books = await _context.Books.Select(x => _mapper.Map<BookDTO>(x))
                             .Skip((page - 1) * (int)pageResults)
                             .Take((int)pageResults)
                             .ToListAsync();
                //Making the BookResponse
                var response = new BookResponse()
                {
                    Books = books,
                    Pages = (int)pageCount,
                    CurrentPages = page
                };
                if (response.Books.Count() == 0)
                    return new ServiceResponse<BookResponse>() { Message = "No data in this page", Success = false };

                return new ServiceResponse<BookResponse>() { Data = response };
            }
            catch (Exception e)
            {
                return new ServiceResponse<BookResponse>() { Message = e.Message, Success = false };           
            }
        }
    }
}
