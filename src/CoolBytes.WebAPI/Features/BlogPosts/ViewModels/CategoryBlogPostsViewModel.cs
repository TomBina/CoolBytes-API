﻿using System.Collections.Generic;

namespace CoolBytes.WebAPI.Features.BlogPosts.ViewModels
{
    public class CategoryBlogPostsViewModel
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public List<BlogPostSummaryViewModel> BlogPosts { get; set; }
    }
}