using Microsoft.AspNetCore.Mvc;
using Telefon_Rehberi.Models.Context;
using Telefon_Rehberi.Models.Entities;

namespace Telefon_Rehberi.Controllers
{
    public class KisiController : Controller
    {
        TelefonRehberiContext db =new TelefonRehberiContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ekle()
        {


            return View();
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
