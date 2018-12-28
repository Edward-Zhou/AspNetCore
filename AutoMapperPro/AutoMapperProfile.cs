using AutoMapper;
using AutoMapperPro.Models;
using AutoMapperPro.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderViewModel, Order>()
                .ForMember(dest => dest.OrderItem, opt => opt.MapFrom(src => src.OrderItemViewModel));
            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<Order, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
