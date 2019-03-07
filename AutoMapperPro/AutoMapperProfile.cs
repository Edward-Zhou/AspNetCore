using AutoMapper;
using AutoMapperPro.Models;
using AutoMapperPro.Models.AccountSubscription;
using AutoMapperPro.Models.Movie;
using Microsoft.EntityFrameworkCore;
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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Client, ClientDto>()
                   .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                   .ForMember(dest => dest.CompanyStreet, opt => opt.MapFrom(src => src.Company.Street));
            });
            CreateMap<OrderViewModel, Order>()
                .ForMember(dest => dest.OrderItem, opt => opt.MapFrom(src => src.OrderItemViewModel));
            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<Order, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<IList<AccountSubscription>, IList<AccountSubscriptionDto>>()
                   .ConstructUsing(list => list.GroupBy(g => new { g.CustomerNumber })
                       .Select(s => new AccountSubscriptionDto
                       {
                           CustomerNumber = s.Key.CustomerNumber,
                           AccountList = s.Select(t => t.AccountNumber).ToList()
                       }).ToList()
                   );
            CreateMap<IPagedList<AccountSubscription>, IPagedList<AccountSubscriptionDto>>()
                .ConstructUsing(source => source.Items.GroupBy(g => new { g.CustomerNumber })
                    .Select(s => new AccountSubscriptionDto
                    {
                        CustomerNumber = s.Key.CustomerNumber,
                        AccountList = s.Select(t => t.AccountNumber).ToList()
                    }).ToPagedList(source.PageIndex, source.PageSize, source.IndexFrom)
                );
        }
    }
}
