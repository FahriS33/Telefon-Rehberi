using Microsoft.AspNetCore.Mvc;
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

            var model = new KisiEkleModelView {

                Kisi = new Kisiler(),
                Sehir =db.iletisimbil.ToList()

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Kisiler kisi)
        {
            db.Kisiler.Add(kisi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
