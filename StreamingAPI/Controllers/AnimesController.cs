﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingAPI.Data;
using StreamingAPI.Models;

namespace StreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly StreamingAPIContext _context;

        public AnimesController(StreamingAPIContext context)
        {
            _context = context;
        }

        // GET: api/Animes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAnime()
        {
          if (_context.Anime == null)
          {
              return NotFound();
          }
            return await _context.Anime.ToListAsync();
        }

        // GET: api/Animes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetAnime(int id)
        {
          if (_context.Anime == null)
          {
              return NotFound();
          }
            var anime = await _context.Anime.FindAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return anime;
        }

        // PUT: api/Animes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnime(int id, Anime anime)
        {
            if (id != anime.Id)
            {
                return BadRequest();
            }

            _context.Entry(anime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anime>> PostAnime(Anime anime)
        {
          if (_context.Anime == null)
          {
              return Problem("Entity set 'ProjetC_Context.Anime'  is null.");
          }
            _context.Anime.Add(anime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime", new { id = anime.Id }, anime);
        }

        // DELETE: api/Animes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            if (_context.Anime == null)
            {
                return NotFound();
            }
            var anime = await _context.Anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }

            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeExists(int id)
        {
            return (_context.Anime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
