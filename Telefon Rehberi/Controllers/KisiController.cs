using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ViewBag.Sehirler = new SelectList(db.iletisimbil.ToList(), "Id", "Konum");

            return (View(kisi));

        }
        [HttpPost]
        public ActionResult Guncelle(Kisiler kisi)
        {
            var eskikisibilgi = db.Kisiler.Find(kisi.Id);

            if(eskikisibilgi== null)
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
    }
}
