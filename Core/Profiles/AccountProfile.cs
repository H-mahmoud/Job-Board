using AutoMapper;
using Job_Board.Models;
using Job_Board.ViewModel;

namespace Job_Board.Core.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterViewModel, UserModel>();
        }
    }
}
