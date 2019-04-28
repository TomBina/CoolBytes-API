﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CoolBytes.Core.Abstractions;
using CoolBytes.Core.Domain;
using CoolBytes.WebAPI.Features.Authors.CQ;
using CoolBytes.WebAPI.Features.Authors.ViewModels;
using MediatR;

namespace CoolBytes.WebAPI.Features.Authors.Handlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorViewModel>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<AuthorViewModel> Handle(GetAuthorQuery message, CancellationToken cancellationToken)
        {
            Author author;
            if (message.IncludeProfile)
            {
                author = await _authorService.GetAuthorWithProfile();
            }
            else
            {
                author = await _authorService.GetAuthor();
            }

            return CreateViewModel(author);
        }

        private AuthorViewModel CreateViewModel(Author author) => Mapper.Map<AuthorViewModel>(author);
    }
}