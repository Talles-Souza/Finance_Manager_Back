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
            CreateMap<SpendDTO, Spend>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(d => d.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(d => d.Account, opt => opt.Ignore());
            CreateMap<AccountDTO, Account>();

        }
    }
}
