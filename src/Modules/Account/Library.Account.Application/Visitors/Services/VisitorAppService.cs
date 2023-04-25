using AutoMapper;
using Library.Account.Application.Visitors.Dto_s;
using Library.Account.Domain.Visitors;
using Library.Account.Domain.Visitors.Services;

namespace Library.Account.Application.Visitors.Services
{
    public class VisitorAppService : IVisitorAppService
    {
        private readonly IVisitorService _visitorService;
        private readonly IMapper _mapper;

        public VisitorAppService(IVisitorService visitorService,
                                 IMapper mapper)
        {
            _visitorService = visitorService;
            _mapper = mapper;
        }

        public async Task<VisitorDto> CreateVisitorAsync(VisitorDto dto)
        {
            var visitor = _mapper.Map<Visitor>(dto);
            visitor = await _visitorService.CreateVisitorAsync(visitor);

            return _mapper.Map<VisitorDto>(visitor);
        }
    }
}