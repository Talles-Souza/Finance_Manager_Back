using AutoMapper;
using Domain.Entities;
using Service.DTOS.AccountDTO;
using Service.DTOS.SpendDTO;
using Service.DTOS.UserDTO;

namespace Service.Mapping
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<SpendDTO, Spend>();
            CreateMap<AccountDTO, Account>();

        }
    }
}
