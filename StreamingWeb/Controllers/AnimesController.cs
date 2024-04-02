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
    public class AnimesController : Controller
    {
       /* private readonly StreamingAPIContext _context;

        public AnimesController(StreamingAPIContext context)
        {
            _context = context;
        }*/

        // GET: Animes
        public IActionResult Index()
        {
           
            
            var animes = API.Instance.GetAnimesAsync().Result;

            return View(animes);
            
        }

        // GET: Animes/Details/5
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

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anime anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutAnimeAsync(anime);
                return Redirect("/Animes");
            }
            return Redirect("/Animes");
        }

        // GET: Animes/Edit/5
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

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Anime anime)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.ModifAnimeAsync(anime);
                return Redirect("/Animes");
            }
            return Redirect("/Animes");
        }

        // GET: Animes/Delete/5
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

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var URI = API.Instance.SupprAnimeAsync(id);
            return Redirect("/Animes");

        }

        /*private bool AnimeExists(int id)
        {
          return (_context.Anime?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
