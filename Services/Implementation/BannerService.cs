using Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class BannerService : IBanners
    {
        private readonly ApplicationDbContext _context;
        public BannerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(Banner banner)
        {
            _context.Add(banner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var banner = GetById(id);
            if (banner != null)
            {
                _context.Remove(banner);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Banner> GetAll()
        {
            return _context.Banners.ToList();
        }

        public Banner GetById(int id)
        {
            return _context.Banners.FirstOrDefault(m => m.Id == id);
        }

        public async Task UpdateAsSync(Banner banner)
        {
            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();
        }
    }
}
