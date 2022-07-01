using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siimple_Back__End.DAL;
using Siimple_Back__End.View_models;
using System.Linq;
using System.Threading.Tasks;

namespace Siimple_Back__End.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Abouts = await _context.Abouts.FirstOrDefaultAsync(),
                Services=await _context.Services.ToListAsync(),
            };
            return View(model);
           
        }
    }
}
