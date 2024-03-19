using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using zeroHunger.EF;
using zeroHunger.DTOs;

namespace zeroHunger.Mappings
{
    public class DetailProfile : Profile
    {
        public DetailProfile()
        {
            CreateMap<Detail, DetailDTO>();
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<Order, Detail>()
                .ForMember(dest => dest.collectId, opt => opt.Ignore())
                .ForMember(dest => dest.resName, opt => opt.MapFrom(src => src.resName))
                .ForMember(dest => dest.foodName, opt => opt.MapFrom(src => src.foodName))
                .ForMember(dest => dest.timeRemained, opt => opt.MapFrom(src => src.prsrvTime))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.orderStatus))
                .ForMember(dest => dest.rider, opt => opt.MapFrom(src => src.riderId))
                .ForMember(dest => dest.rId, opt => opt.MapFrom(src => src.rId));
        }
    }
}
