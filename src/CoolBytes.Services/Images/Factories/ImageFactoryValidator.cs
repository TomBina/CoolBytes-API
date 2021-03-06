﻿using System.IO;
using System.Linq;
using CoolBytes.Core.Abstractions;
using CoolBytes.Core.Attributes;

namespace CoolBytes.Services.Images.Factories
{
    [Inject(typeof(IImageFactoryValidator))]
    public class ImageFactoryValidator : IImageFactoryValidator
    {
        private const int MaxFileSize = (1024 * 1024) * 3;
        private readonly string[] _allowedContentTypes;

        public ImageFactoryValidator()
        {
            _allowedContentTypes = new []
            {
                "image/jpeg",
                "image/jpg",
                "image/png",
                "image/gif",
                "image/svg+xml"
            };
        }

        public bool Validate(Stream stream, string contentType) => 
            _allowedContentTypes.Any(c => c == contentType) && (stream.Length <= MaxFileSize && stream.Length > 0);
    }
}