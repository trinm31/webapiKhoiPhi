using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WepApiKhoiPhi.Authorization;
using WepApiKhoiPhi.DbContext;
using WepApiKhoiPhi.Dtos;
using WepApiKhoiPhi.Models;
using WepApiKhoiPhi.Services.IServices;

namespace WepApiKhoiPhi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        // http://localhost:5000/api/books
        public IList<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _bookService.GetById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(BookUpSertRequest input)
        {
            var book = _mapper.Map<Book>(input);
            
            _bookService.Create(book);
            
            return Ok(book);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id,BookUpSertRequest input)
        {
            var book = _bookService.GetById(id);
            
            book.Name = input.Name;
            book.Author = input.Author;
            book.PageNumber = input.PageNumber;
            book.PublishDate = input.PublishDate;

            _bookService.Update(book);
            
            return Ok(book);
        }
        
        [Authorize(Role.Admin)]
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _bookService.Delete(id);

            if (!result)
                return BadRequest();
            
            return Ok();
        }
    }
}