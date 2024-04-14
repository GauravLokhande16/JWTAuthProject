using AutoMapper;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, CouponDto>();
                config.CreateMap<CouponDto, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
