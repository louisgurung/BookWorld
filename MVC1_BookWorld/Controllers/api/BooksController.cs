using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.Dtos;
using AutoMapper;

namespace MVC1_BookWorld.Controllers.api
{
    public class BooksController : ApiController
    {

        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Books

        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books.ToList().Select(Mapper.Map<Book,BookDto>);
        }

        //get by id
        public BookDto GetBook(int id)
        {
            
          var book = _context.Books.SingleOrDefault(c => c.ID == id);

          if (book==null)
          {
                throw new HttpResponseException(HttpStatusCode.NotFound);
          }

          return Mapper.Map<Book, BookDto>(book);
        }

        [HttpPost]
        public BookDto CreateBook(BookDto bookDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var book = Mapper.Map<BookDto, Book>(bookDto);

            _context.Books.Add(book);
            _context.SaveChanges();

            return bookDto;
        }

        [HttpPut]
        public void UpdateBook(int id, BookDto bookDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDb = _context.Books.SingleOrDefault(c => c.ID == id);

            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<BookDto, Book>(bookDto, bookInDb);

           // bookInDb.Name = bookDto.Name;
            //bookInDb.DateAdded = bookDto.DateAdded;
            //bookInDb.NumberInStock = bookDto.NumberInStock;
            //bookInDb.GenreId = bookDto.GenreId;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDb = _context.Books.SingleOrDefault(c => c.ID == id);

            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

        }


    }
   }

