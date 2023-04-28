using AutoMapper;
using Library.Account.Application.Visitors.Dto_s;
using Library.Account.Domain.Visitors;
using Library.Account.Domain.Visitors.ValueObjects;

namespace Library.Account.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<VisitorDto, Visitor>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}