using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.Dtos;
using AutoMapper;
using System.Data.Entity;  //to use genre

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

        public /*IEnumerable<BookDto>*/IHttpActionResult GetBooks(string query=null)

        {

            // var x = _context.Books.Include(b=> b.Genre).ToList();
            // return _context.Books.ToList().Select(Mapper.Map<Book,BookDto>);
            //var bookDtos = _context.Books
            //    .Include(c => c.Genre)
            //    .ToList()
            //    .Select(Mapper.Map<Book, BookDto>);
            var booksQuery = _context.Books.Include(c => c.Genre);

            if (!String.IsNullOrWhiteSpace(query))
               booksQuery = booksQuery.Where(c => c.Name.Contains(query));

            var bookDtos = booksQuery.ToList().Select(Mapper.Map<Book,BookDto>);


            return Ok(bookDtos);
        }

        //get by id
        public /*BookDto*/IHttpActionResult GetBook(int id)
        {
            
          var book = _context.Books.SingleOrDefault(c => c.ID == id);

          if (book==null)
          {
              //  throw new HttpResponseException(HttpStatusCode.NotFound);
              return NotFound();
          }

         // return Mapper.Map<Book, BookDto>(book);
         return Ok(Mapper.Map<Book, BookDto>(book));
        }

        [HttpPost]
        public /*BookDto*/IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var book = Mapper.Map<BookDto, Book>(bookDto);

            _context.Books.Add(book);
            _context.SaveChanges();

           // return bookDto;
           bookDto.ID = book.ID;

           return Created(new Uri(Request.RequestUri+"/"+ book.ID.ToString()),bookDto );


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

