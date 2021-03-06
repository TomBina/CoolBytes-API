﻿using AutoMapper;
using CoolBytes.Core.Domain;

namespace CoolBytes.WebAPI.Features.BlogPosts.DTO
{
    [AutoMap(typeof(BlogPostTag))]
    public class BlogPostTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}