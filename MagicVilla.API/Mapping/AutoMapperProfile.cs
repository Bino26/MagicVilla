using AutoMapper;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Models.DTOs;

namespace MagicVilla.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Villa,VillaDto>().ReverseMap();
            CreateMap<CreateVillaDto,Villa>().ReverseMap();
            CreateMap<UpdateVillaDto,Villa>().ReverseMap();

            CreateMap<VillaNumber,VillaNumberDto>().ReverseMap();
            CreateMap<AddVillaNumberDto, VillaNumber>().ReverseMap();
            CreateMap<UpdateVillaNumberDto,VillaNumber>().ReverseMap();
        }
    }
}
