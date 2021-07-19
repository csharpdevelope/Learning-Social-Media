﻿using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.InfraStructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
