﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Mappers;
using MVC1_BookWorld.Dtos;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.Controllers.api
{
    public class CustomersController : ApiController
    {
        //api and dto mapping 
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }

        //GET/api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }


        //get by id
        public /*CustomerDto*/IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            //return Mapper.Map<Customer,CustomerDto>(customer);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        //POST/api/customers
        [HttpPost]
        public /*CustomerDto*/ IHttpActionResult CreateCustomer(/*[FromBody] */CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.ID= customer.ID;

            //return customerDto;    
            return Created(new Uri(Request.RequestUri + "/" + customer.ID.ToString()), customerDto);

        }

        //PUT/api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

           // customerInDb.Name = customerDto.Name;
           // customerInDb.BirthDate = customerDto.BirthDate;
           // customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
          // customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();

        }


        //DELETE/api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }


    }
}
