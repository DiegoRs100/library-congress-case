using Library.Account.Application.Visitors.Dto_s;

namespace Library.Account.Application.Visitors.Services
{
    public interface IVisitorAppService
    {
        public Task<VisitorDto> CreateVisitorAsync(VisitorDto dto);
    }
}