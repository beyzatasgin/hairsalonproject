using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using kuaforsalonu.Models;
using Microsoft.EntityFrameworkCore;


namespace kuaforsalonu.Controllers
{
    public class AdminMusteriController : Controller
    {
        private readonly Kuaforsalonu _context;

        public AdminMusteriController(Kuaforsalonu context)
        {
            _context = context;
        }

        // GET: AdminMusteri
        public async Task<IActionResult> Index()
        {
            var musteris = await _context.Musteriler.ToListAsync();
            return View(musteris);
        }

        // GET: AdminMusteri/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var musteri = await _context.Musteriler
                .FirstOrDefaultAsync(m => m.MusteriNo == id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        // GET: AdminMusteri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminMusteri/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        // GET: AdminMusteri/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
          
            return View(musteri);
        }

        // POST: AdminMusteri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Musteri musteri)
        {
            if (id != musteri.MusteriNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteri);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
      
            return View(musteri);
        }

        // GET: AdminMusteri/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var musteri = await _context.Musteriler
                .FirstOrDefaultAsync(m => m.MusteriNo == id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        // POST: AdminMusteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
