using Core.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Application.Services
{
    public class LinkService
    {
        private readonly ApplicationDbContext _context;
        private const int ShortUrlLength = 8;

        public LinkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateShortUrlAsync()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            while (true)
            {
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(ShortUrlLength))
                    .Replace("+", "").Replace("/", "").Replace("=", "")[..ShortUrlLength];

                if (!await _context.Links.AnyAsync(l => l.ShortUrl == token))
                    return token;
            }
        }

        public async Task<Link?> GetByShortUrlAsync(string shortUrl) =>
            await _context.Links.FirstOrDefaultAsync(l => l.ShortUrl == shortUrl);

        public async Task<List<Link>> GetAllLinksAsync() =>
            await _context.Links.OrderByDescending(l => l.CreatedDate).ToListAsync();

        public async Task AddLinkAsync(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLinkAsync(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementClickCountAsync(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                link.ClickCount++;
                await _context.SaveChangesAsync();
            }
        }
    }
}
