﻿using AutoMapper;
using CoolBytes.Core.Models;
using CoolBytes.WebAPI.Features.BlogPosts.DTO;

namespace CoolBytes.WebAPI.Features.BlogPosts.Profiles
{
    public class ExternalLinkDtoProfile : Profile
    {
        public ExternalLinkDtoProfile()
        {
            CreateMap<ExternalLink, ExternalLinkDto>();
        }
    }
}
