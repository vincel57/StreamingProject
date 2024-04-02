using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamingAPI.Data;
using StreamingAPI.Models;
using StreamingWeb.ControllerAPI;


namespace StreamingWeb.Controllers
{
    public class AdminsController : Controller
    {
        /* private readonly StreamingAPIContext _context;

         public AdminsController(StreamingAPIContext context)
         {
             _context = context;
         }*/

        // GET: Admins
        public IActionResult Index()
        {


            var admins = API.Instance.GetAdminsAsync().Result;

            return View(admins);

        }

        // GET: Admins/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anime = API.Instance.GetAnimeAsync(id).Result;

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);

        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anime anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutAnimeAsync(anime);
                return Redirect("/Admins");
            }
            return Redirect("/Admins");
        }

        // GET: Admins/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = API.Instance.GetAnimeAsync(id).Result;
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Anime anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.ModifAnimeAsync(anime);
                return Redirect("/Admins");
            }
            return Redirect("/Admins");
        }

        // GET: Admins/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = API.Instance.GetAnimeAsync(id).Result;
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var URI = API.Instance.SupprAnimeAsync(id);
            return Redirect("/Admins");

        }

        /*private bool AnimeExists(int id)
        {
          return (_context.Anime?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
