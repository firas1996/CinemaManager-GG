using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Cinema;

namespace WebApplication1.Controllers
{
    public class ProducersController : Controller
    {
        CinemaDBContext ctx;
        public ProducersController(CinemaDBContext context)
        {
            ctx= context;
        }
        // GET: ProducersController
        public ActionResult Index()
        {
            return View(ctx.Producers.ToList());
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {
            Producer p = ctx.Producers.Find(id);

            return View(p);
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer prod)
        {
            try
            {
                ctx.Producers.Add(prod);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {
            Producer p = ctx.Producers.Find(id);
            return View(p);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Producer prod)
        {
            try
            {
                ctx.Producers.Update(prod);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            Producer p = ctx.Producers.Find(id);

            return View(p);
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection,Producer prod)
        {
            try
            {
                ctx.Producers.Remove(prod);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
