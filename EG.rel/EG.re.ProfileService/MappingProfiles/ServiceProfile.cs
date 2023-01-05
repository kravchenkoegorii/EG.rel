﻿using EG.rel.ProfileService.DTOs;
using EG.rel.ProfileService.Entities;

namespace EG.rel.ProfileService.MappingProfiles
{
    public class EnergySavingsAnalyticServiceProfile : AutoMapper.Profile
    {
        public EnergySavingsAnalyticServiceProfile()
        {
            CreateMap<EG.rel.ProfileService.Entities.ProfileUser, ProfileDto>().ReverseMap();
            CreateMap<EG.rel.ProfileService.Entities.ProfileUser, InsertProfileDto>().ReverseMap();
            CreateMap<Address, InsertAddressDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Hobby, InsertHobbyDto>().ReverseMap();
            CreateMap<Hobby, HobbyDto>().ReverseMap();
        }
    }
}
