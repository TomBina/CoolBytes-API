﻿using CoolBytes.Core.Utils;
using CoolBytes.WebAPI.Features.BlogPosts.ViewModels;
using MediatR;

namespace CoolBytes.WebAPI.Features.BlogPosts.CQ
{
    public class GetBlogPostQuery : IRequest<Result<BlogPostViewModel>>
    {
        public int Id { get; set; }
    }
}
