using APIexamen.DTOs;
using APIexamen.Entities;
using AutoMapper;
namespace APIexamen.Utilities
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
