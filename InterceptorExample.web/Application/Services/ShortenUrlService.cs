﻿using InterceptorExample.web.Domain;
using InterceptorExample.web.Infrastructure.Persistence;

namespace InterceptorExample.web.Application.Services
{
    public class ShortenUrlService
    {
        private readonly SqlServerApplicationDbContext _context;

        public ShortenUrlService(SqlServerApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateShortenLink(string destinationLink, CancellationToken cancellationToken)
        {
            string shortenCode = GenerateCode();
            Link link = new()
            {
                shortenUrl = shortenCode,
                destenationUrl = destinationLink
            };
            await _context.Links.AddAsync(link,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return $"https://localhost:7084/{shortenCode}";
        }

        public string GenerateCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }


    }
}
