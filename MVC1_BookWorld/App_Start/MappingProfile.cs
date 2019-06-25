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
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();      //generic method takes source and target

            Mapper.CreateMap<Book, BookDto>();

             Mapper.CreateMap<MembershipType,MembershipTypeDto>();

             Mapper.CreateMap<Genre,GenreDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.ID, opt => opt.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(c => c.ID, opt => opt.Ignore());

            Mapper.CreateMap<GenreDto, Genre>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}