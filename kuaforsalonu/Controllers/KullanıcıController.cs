using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kuaforsalonu.Models;



namespace kuaforsalonu.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly Kuaforsalonu _db;

        // Constructor: Dependency Injection ile DbContext
        public KullanıcıController(Kuaforsalonu db)
        {
            _db = db;
        }

        // Kullanıcı bilgilerini görüntüle
        public IActionResult Index(int id)
        {
            var uye = _db.Musteris.SingleOrDefault(m => m.MusteriNo == id);
            if (uye == null || (int?)HttpContext.Session.GetInt32("üyeid") != uye.MusteriNo)
            {
                return NotFound(); // Giriş yapmamış kullanıcı için hata döndürme
            }
            return View(uye); // Kullanıcı bilgilerini gösterme
        }

        // Login sayfası (Giriş sayfası)
        public IActionResult Login()
        {
            return View();
        }

        // Login işlemi (Giriş yapmak)
        [HttpPost]
        public async Task<IActionResult> Login(Musteri müşteri)
        {
            var login = _db.Musteris.SingleOrDefault(m => m.KullaniciAdi == müşteri.KullaniciAdi);
            if (login != null && login.Sifre == müşteri.Sifre)
            {
                // Giriş başarılı, oturum bilgilerini kaydetme
                HttpContext.Session.SetInt32("üyeid", login.MusteriNo);
                HttpContext.Session.SetString("KullanıcıAdı", login.KullaniciAdi);
                HttpContext.Session.SetInt32("yetkiid", login.YetkiNo);

                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirme
            }
            else
            {
                return View(); // Hatalı giriş, tekrar giriş yapmasını istemek
            }
        }

        // Logout işlemi (Çıkış yapma)
        public IActionResult Logout()
        {
            // Kullanıcı çıkışı işlemleri
            HttpContext.Session.Clear(); // Tüm session verilerini temizle

            return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirme
        }

        // Yeni kullanıcı eklemek için form sayfası
        public IActionResult Create()
        {
            return View();
        }

        // Yeni kullanıcıyı eklemek
        [HttpPost]
        public async Task<IActionResult> Create(Musteri müşteri)
        {
            if (ModelState.IsValid)
            {
                müşteri.YetkiNo = 2; // Varsayılan yetkiyi belirleme

                _db.Musteris.Add(müşteri); // Kullanıcıyı veri tabanına ekle
                await _db.SaveChangesAsync(); // Değişiklikleri kaydet

                // Oturum bilgilerini kaydet
                HttpContext.Session.SetInt32("üyeid", müşteri.MusteriNo);
                HttpContext.Session.SetString("KullanıcıAdı", müşteri.KullaniciAdi);

                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirme
            }
            return View(müşteri); // Hata varsa tekrar formu göster
        }

        // Kullanıcı bilgilerini düzenlemek için form sayfası
        public IActionResult Edit(int id)
        {
            var uye = _db.Musteris.SingleOrDefault(m => m.MusteriNo == id);
            if (uye == null || (int?)HttpContext.Session.GetInt32("üyeid") != uye.MusteriNo)
            {
                return NotFound(); // Giriş yapmamışsa hata döndürme
            }
            return View(uye); // Kullanıcıyı düzenleme sayfasına yönlendirme
        }

        // Kullanıcı bilgilerini güncellemek
        [HttpPost]
        public async Task<IActionResult> Edit(Musteri müşteri, int id)
        {
            if (ModelState.IsValid)
            {
                var müşteris = _db.Musteris.SingleOrDefault(m => m.MusteriNo == id);
                if (müşteris == null)
                {
                    return NotFound(); // Kullanıcı bulunamadıysa hata döndürme
                }

                // Kullanıcı bilgilerini güncelleme
                müşteris.Adi = müşteri.Adi;
                müşteris.Adres = müşteri.Adres;
                müşteris.Email = müşteri.Email;
                müşteris.KullaniciAdi = müşteri.KullaniciAdi;
                müşteris.Soyadi = müşteri.Soyadi;
                müşteris.Sifre = müşteri.Sifre;
                müşteris.Telefon = müşteri.Telefon;

                await _db.SaveChangesAsync(); // Değişiklikleri kaydet

                // Oturum bilgilerini güncelle
                HttpContext.Session.SetString("KullanıcıAdı", müşteri.KullaniciAdi);

                return RedirectToAction("Index", "Home", new { id = müşteris.MusteriNo }); // Güncellenmiş bilgileri ana sayfada göster
            }
            return View(müşteri); // Hata varsa formu tekrar göster
        }
    }
}
