﻿using System.Threading.Tasks;
using CoolBytes.Core.Abstractions;
using CoolBytes.Core.Attributes;
using CoolBytes.Core.Domain;
using CoolBytes.Data;
using Microsoft.EntityFrameworkCore;

namespace CoolBytes.Services
{
    [Inject(typeof(IAuthorValidator))]
    public class AuthorValidator : IAuthorValidator
    {
        private readonly AppDbContext _appDbContext;

        public AuthorValidator(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Exists(User user) => await FoundAnyAuthor(user);

        public async Task<bool> Exists(IUserService userService)
        {
            var user = await userService.TryGetCurrentUserAsync();

            if (!user)
                return false;

            return await FoundAnyAuthor(user.Payload);
        }

        private async Task<bool> FoundAnyAuthor(User user) => await _appDbContext.Authors.AnyAsync(a => a.UserId == user.Id);
    }
}