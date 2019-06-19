using Vidly.Dtos;
using Vidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;


namespace Vidly.App_Start
{
    public class MappingProfile : Profile

    {
        public static void Run()

        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MappingProfile>();
            });

        }

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDtos>().ReverseMap();
            CreateMap<Movie, MovieDtos>().ReverseMap();
            CreateMap<MembershipType, MembershipTypeDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
        }
    }
}