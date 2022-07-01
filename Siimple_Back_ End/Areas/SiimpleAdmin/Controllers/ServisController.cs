using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siimple_Back__End.DAL;
using Siimple_Back__End.Models;
using Siimple_Back__End.Utilites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siimple_Back__End.Areas.SiimpleAdmin.Controllers
{
    [Area("SiimpleAdmin")]
    public class ServisController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServisController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Servis> servis = await _context.Services.ToListAsync();
            return View(servis);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Servis servis)
        {
            if (!ModelState.IsValid) return View();
            if (servis.Photo != null)
            {
                if (!servis.Photo.ContentType.Contains("image"))
                {
                    return View();
                }
                if (servis.Photo.Length > 1024 * 1024)
                {
                    return View();
                }
            }
            servis.Image = await servis.Photo.FileCreate(_env.WebRootPath, @"assets/img");
            await _context.Services.AddAsync(servis);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            Servis servis = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            return View(servis);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Servis servis)
        {
            if (!ModelState.IsValid) return View();
            Servis existedservis = await _context.Services.FirstOrDefaultAsync(s => s.Id==servis.Id );
            if (existedservis == null) return View();
         

            existedservis.Title = servis.Title;
            existedservis.Description = servis.Description;
            existedservis.Icon = servis.Icon;
            existedservis.Photo = servis.Photo;
          
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Servis servis = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            return View(servis);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteServis(int id)
        {
            Servis servis = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (servis == null) return View();

            _context.Services.Remove(servis);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
