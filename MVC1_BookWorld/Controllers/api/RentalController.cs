using AutoMapper;
using MVC1_BookWorld.Dtos;
using MVC1_BookWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MVC1_BookWorld.Controllers.api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto RentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //var rental = _context.Rentals.SingleOrDefault(c => c.ID == RentalDto.ID);
            //if (rental == null)
            //{
            //    return BadRequest("Invalid customer ID");
            //}         this is if wrong id is given
            if (RentalDto.BooksIds.Count == 0)
                return BadRequest("No Book ids have been given.");

            //var customer = _context.Customers.SingleOrDefault(c => c.ID == RentalDto.CustomerId);
            ////handling edge case when customer id is not valid
            //if (customer == null)
            //    return BadRequest("Customer ID is not valid");

            //var books = _context.Books.Where(m => RentalDto.BooksIds.Contains(m.ID)).ToList();     //list in a var

            //if (books.Count != RentalDto.BooksIds.Count)
            //    return BadRequest("One or more BookIds are invalid");


            var customer = _context.Customers.SingleOrDefault(c => c.ID == RentalDto.CustomerId);

            var books = _context.Books.Where(m => RentalDto.BooksIds.Contains(m.ID));     //list in a var

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available.");

                book.NumberAvailable--;
                var rental = new Rental 
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
            //  return Created(new Uri(Request.RequestUri+"/"+rental.ID.ToString()),RentalDto);
        }

        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var rentalDtos = _context.Rentals.ToList()
                .Select(Mapper.Map<Rental,RentalDto>);

            return Ok(rentalDtos);
        }

        [HttpGet]
        public IHttpActionResult GetRentals(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.ID == id);

            if (rental == null)

                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        [HttpPut]
        public void UpdateRental(int id,RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.ID == id);

            if (rentalInDb == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map<RentalDto, Rental>(rentalDto, rentalInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.ID == id);

            if (rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }
    }
}
