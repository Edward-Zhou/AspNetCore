using AutoMapper;
using EFCorePro.Models.ManyToMany;
using EFCorePro.Models.OneToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ArticleTags.Select(at => at.Tag)));
            CreateMap<Tag, TagViewModel>();
            CreateMap<ItemInput, Item>();
            CreateMap<ItemTagInput, ItemTag>();

        }
    }
}
