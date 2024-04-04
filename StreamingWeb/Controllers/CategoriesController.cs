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
    public class CategoriesController : Controller
    {
        /* private readonly StreamingAPIContext _context;

         public CategoriesController(StreamingAPIContext context)
         {
             _context = context;
         }*/

        // GET: Categories
        public IActionResult Index()
        {


            var animes = API.Instance.GetCategoriesAsync().Result;

            return View(animes);

        }

        // GET: Categories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anime = API.Instance.GetCategorieAsync(id).Result;

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);

        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutCategorieAsync(anime);
                return Redirect("/Categories");
            }
            return Redirect("/Categories");
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = API.Instance.GetCategorieAsync(id).Result;
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.ModifCategorieAsync(anime);
                return Redirect("/Categories");
            }
            return Redirect("/Categories");
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = API.Instance.GetCategorieAsync(id).Result;
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var URI = API.Instance.SupprCategorieAsync(id);
            return Redirect("/Categories");

        }

        /*private bool CategorieExists(int id)
        {
          return (_context.Categorie?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
