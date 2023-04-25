using AutoMapper;
using Library.Account.Application.Visitors.Dto_s;
using Library.Account.Domain.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Account.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<VisitorDto, Visitor>().ReverseMap();
        }
    }
}