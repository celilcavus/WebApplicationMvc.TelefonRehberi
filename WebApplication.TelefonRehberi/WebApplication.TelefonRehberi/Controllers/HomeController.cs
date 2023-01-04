using System.Web.Mvc;
using WebApplication.TelefonRehberi.Models.Concrete;
using WebApplication.TelefonRehberi.Models.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WebApplication.TelefonRehberi.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext app = null;
        public HomeController()
        {
            app = new AppDbContext();
            if (app.Database.Exists() == false)
            {
                app.Database.Create();
            }


        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Rehber rehber)
        {
            Rehber r = new Rehber();
            r.Ad = rehber.Ad;
            r.Soyad = rehber.Soyad;
            r.Telefon = rehber.Telefon;
            app.Rehbers.Add(r);
            app.SaveChanges();
            return View();
        }
        public PartialViewResult getRehberList()
        {
            var returnValue = app.Rehbers.AsNoTracking().ToList();
            return PartialView("_PartialRehberList", returnValue);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var returnList = app.Rehbers.Where(x => x.Id == id).FirstOrDefault();
            if (returnList == null)
                HttpNotFound();

            return View(returnList);
        }
        [HttpPost]
        public ActionResult Guncelle(int id, Rehber r)
        {
            var returnId = app.Rehbers.Where(x => x.Id == id).FirstOrDefault();

            if (returnId != null)
            {
                returnId.Ad = r.Ad;
                returnId.Soyad = r.Soyad;
                returnId.Telefon = r.Telefon;
                int x = app.SaveChanges();
                if (x >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpNotFound();
                }
            }
            else
            {
                HttpNotFound();
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            var returnId = app.Rehbers.Find(id);
            if (returnId != null)
            {
                app.Rehbers.Remove(returnId);
                int x = app.SaveChanges();
                if (x >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpNotFound();
                }
            }
            else
            {
                HttpNotFound();
            }
            return View();
        }
    }
}