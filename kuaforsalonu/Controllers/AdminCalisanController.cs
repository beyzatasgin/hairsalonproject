using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using kuaforsalonu.Models;
using Microsoft.EntityFrameworkCore;

namespace kuaforsalonu.Controllers
{
    public class AdminCalisanController : Controller
    {
        private readonly Kuaforsalonu _db;

        public AdminCalisanController(Kuaforsalonu db)
        {
            _db = db;
        }

        // GET: AdminCalisan
        public async Task<IActionResult> Index()
        {
            var calisans = await _db.Calisans.ToListAsync();
            return View(calisans);
        }

        // GET: AdminCalisan/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var calisan = await _db.Calisans.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // GET: AdminCalisan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCalisan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _db.Calisans.Add(calisan);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calisan);
        }

        // GET: AdminCalisan/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var calisan = await _db.Calisans.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // POST: AdminCalisan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Calisan calisan)
        {
            if (id != calisan.CalisanNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(calisan);
                    await _db.SaveChangesAsync();
                }
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calisan);
        }

        // GET: AdminCalisan/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var calisan = await _db.Calisans.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // POST: AdminCalisan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calisan = await _db.Calisans.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }

            // Remove related Randevus
            var randevus = _db.Randevus.Where(r => r.CalisanNo == id).ToList();
            _db.Randevus.RemoveRange(randevus);

            // Remove the Calisan
            _db.Calisans.Remove(calisan);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
