using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using kuaforsalonu.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace kuaforsalonu.Controllers
{
    public class UyeRandevuController : Controller
    {
        private readonly Kuaforsalonu _db;

        public UyeRandevuController(Kuaforsalonu db)
        {
            _db = db;
        }

        // GET: UyeRandevu
        public async Task<IActionResult> Index()
        {
            var randevus = await _db.Randevular.Include(r => r.Calisan).Include(r => r.Saat).ToListAsync();
            return View(randevus);
        }

        // GET: UyeRandevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var randevu = await _db.Randevular
                .Include(r => r.Calisan)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(r => r.RandevuID == id);

            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        public async Task<IActionResult> Details2()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetString("üyeid"));
            var randevus = await _db.Randevular.Include(r => r.Calisan).Include(r => r.Saat)
                .Where(r => r.MusteriNo == id)
                .ToListAsync();

            if (randevus == null || !randevus.Any())
            {
                return NotFound();
            }

            return View(randevus.First());
        }

        // GET: UyeRandevu/Create
        public IActionResult Create()
        {
            ViewData["CalisanNo"] = new SelectList(_db.Calisans, "CalisanNo", "Adi");
            ViewData["SaatID"] = new SelectList(_db.Saatler, "SaatID", "Adi");
            return View();
        }

        // POST: UyeRandevu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuID,CalisanNo,Tarih,SaatID")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                randevu.MusteriNo = Convert.ToInt32(HttpContext.Session.GetString("üyeid"));
                _db.Randevular.Add(randevu);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Details2));
            }

            ViewData["CalisanNo"] = new SelectList(_db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
            ViewData["SaatID"] = new SelectList(_db.Saatler, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // GET: UyeRandevu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var randevu = await _db.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }

            ViewData["CalisanNo"] = new SelectList(_db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
            ViewData["SaatID"] = new SelectList(_db.Saatler, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // POST: UyeRandevu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuID,MusteriNo,CalisanNo,Tarih,SaatID")] Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    randevu.MusteriNo = Convert.ToInt32(HttpContext.Session.GetString("üyeid"));
                    _db.Update(randevu);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CalisanNo"] = new SelectList(_db.Calisans, "CalisanNo", "Adi", randevu.CalisanNo);
            ViewData["SaatID"] = new SelectList(_db.Saatler, "SaatID", "Adi", randevu.SaatID);
            return View(randevu);
        }

        // GET: UyeRandevu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var randevu = await _db.Randevular
                .Include(r => r.Calisan)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(r => r.RandevuID == id);

            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: UyeRandevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _db.Randevular.FindAsync(id);
            _db.Randevular.Remove(randevu);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return _db.Randevular.Any(e => e.RandevuID == id);
        }
    }
}
