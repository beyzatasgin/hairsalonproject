using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kuaforsalonu.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace kuaforsalonu.Controllers
{
    public class IslemController : Controller
    {
        private readonly Kuaforsalonu _context;

        public IslemController(Kuaforsalonu context)
        {
            _context = context;
        }

        // GET: Islem
        public async Task<IActionResult> Index()
        {
            var islemler = _context.Islemler.Include(i => i.Salon); // Salon bilgisiyle birlikte işlemleri al
            return View(await islemler.ToListAsync());
        }

        // GET: Islem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var islem = await _context.Islemler
                .Include(i => i.Salon) // İlgili salon bilgisiyle getir
                .FirstOrDefaultAsync(m => m.IslemId == id);
            if (islem == null) return NotFound();

            return View(islem);
        }

        // GET: Islem/Create
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "SalonId", "Ad"); // Salon listesi
            return View();
        }

        // POST: Islem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Islem islem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(islem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Salon", new { id = islem.SalonId }); // İşlem başarıyla eklendikten sonra salonun detaylarına yönlendir
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "SalonId", "Ad", islem.SalonId);
            return View(islem);
        }

        // GET: Islem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var islem = await _context.Islemler.FindAsync(id);
            if (islem == null) return NotFound();

            ViewData["SalonId"] = new SelectList(_context.Salonlar, "SalonId", "Ad", islem.SalonId);
            return View(islem);
        }

        // POST: Islem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Islem islem)
        {
            if (id != islem.IslemId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(islem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslemExists(islem.IslemId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "SalonId", "Ad", islem.SalonId);
            return View(islem);
        }

        // GET: Islem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var islem = await _context.Islemler
                .Include(i => i.Salon)
                .FirstOrDefaultAsync(m => m.IslemId == id);
            if (islem == null) return NotFound();

            return View(islem);
        }

        // POST: Islem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var islem = await _context.Islemler.FindAsync(id);
            _context.Islemler.Remove(islem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslemExists(int id)
        {
            return _context.Islemler.Any(e => e.IslemId == id);
        }
    }
}
