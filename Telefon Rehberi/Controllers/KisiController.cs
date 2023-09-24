using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Telefon_Rehberi.Models.Context;
using Telefon_Rehberi.Models.Entities;
using Telefon_Rehberi.Models.KisiModel;

namespace Telefon_Rehberi.Controllers
{
    public class KisiController : Controller
    {
        TelefonRehberiContext db = new TelefonRehberiContext();
        public ActionResult Index()
        {


            var model = new KisiIndexmodelview
            {
                kisiler = db.Kisiler.ToList(),
                Sehirler = db.iletisimbil.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {

            var model = new KisiEkleModelView
            {

                Kisi = new Kisiler(),
                Sehir = db.iletisimbil.ToList()

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Kisiler kisi)
        {
            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();
                TempData["Basarili"] = "Ekleme İşlemi Tamamlandı.";

            }
            catch (Exception)
            {

                TempData["Basarisiz"] = "Hata oluştu! Ekleme işlemi gerçekleşemedi.";

            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["Basarisiz"] = "Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }

            var model = new KisiGuncelleModelView
            {
                Kisi = kisi,
                Sehirler = db.iletisimbil.ToList()

            };

            ViewBag.Sehirler = new SelectList(db.iletisimbil.ToList(), "Id", "Konum");

            return (View(model));

        }
        [HttpPost]
        public ActionResult Guncelle(Kisiler kisi)
        {
            var eskikisibilgi = db.Kisiler.Find(kisi.Id);

            if (eskikisibilgi == null)
            {
                TempData["basarisiz"] = "Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }

            eskikisibilgi.Ad = kisi.Ad;
            eskikisibilgi.Soyad = kisi.Soyad;
            eskikisibilgi.Firma = kisi.Firma;
            eskikisibilgi.Telefon = kisi.Telefon;
            eskikisibilgi.Email = kisi.Email;
            eskikisibilgi.İletisimId = kisi.İletisimId;

            db.SaveChanges();
            TempData["basarili"] = "Güncelleme İşlemi Başarıyla Tamamlandı!";


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["basarisiz"] = "Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new KisiDetayModelView
            {
                Kisi = kisi,
                Sehirler = db.iletisimbil.ToList()
            };
            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["basarisiz"] = "Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Rapor()
        {

            var sehirler = db.Kisiler
            .GroupBy(k => k.İletisimId)
            .Select(g => new { Sehir = g.Key, KullaniciSayisi = g.Count() })
            .OrderByDescending(g => g.KullaniciSayisi)
            .ToList();
            var model = new KisiRaporModelView
            {
                Sehirler = sehirler
            };
            return View(model);
        }



    }
}
