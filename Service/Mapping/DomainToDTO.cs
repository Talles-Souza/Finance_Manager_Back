﻿using AutoMapper;
using Domain.Entities;
using Service.DTOS.AccountDTO;
using Service.DTOS.SpendDTO;
using Service.DTOS.UserDTO;

namespace Service.Mapping
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<User, UserCreateDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<Spend, SpendDTO>().ForMember(d => d.AccountID, opt => opt.MapFrom(src => src.Account.Number));
            CreateMap<Account, AccountDTO>();

        }
    }
}
