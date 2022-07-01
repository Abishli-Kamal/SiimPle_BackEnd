using Microsoft.EntityFrameworkCore;
using Siimple_Back__End.DAL;
using Siimple_Back__End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siimple_Back__End.Services
{
    public class LayoutSerrvis
    {
        private readonly AppDbContext _context;

        public LayoutSerrvis(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Setting>> GetDatas()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }
        
    }
}
