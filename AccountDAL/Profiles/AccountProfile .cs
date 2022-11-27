using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
