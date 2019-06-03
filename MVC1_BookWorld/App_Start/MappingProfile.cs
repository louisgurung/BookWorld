using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC1_BookWorld.Dtos;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();      //generic method takes source and target
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>();
        }
    }
}