using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using PaginationApi.Services;
using PaginationApi.Services.BookService;

namespace PaginationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<ServiceResponse<BookResponse>>> GetAlBooks(int page)
        {
            return Ok(await _bookServices.GetAllBooks(page));
        }
    }
}
