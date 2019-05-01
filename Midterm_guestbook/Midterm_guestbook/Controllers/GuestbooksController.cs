using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Midterm_guestbook.Models;

namespace Midterm_guestbook.Controllers
{
    public class GuestbooksController : Controller
    {
        private readonly Midterm_guestbookContext _context;

        public GuestbooksController(Midterm_guestbookContext context)
        {
            _context = context;
        }

        // GET: Guestbooks
        [HttpGet, ActionName("Index")]
        public async Task<IActionResult> Index(string str_tags, string str_search)
        {
            // Use LINQ to get list of tags.
            IQueryable<string> genreQuery = from g in _context.Guestbook orderby g.Tag select g.Tag;

            // Important: 查詢｢只｣會在此時定義，它尚未對資料庫執行。
            var data = from g in _context.Guestbook select g;

            if (!String.IsNullOrEmpty(str_search))
            {
                data = data.Where(s => s.Title.Contains(str_search));
            }

            if (!String.IsNullOrEmpty(str_tags))
            {
                data = data.Where(s => s.Tag.Equals(str_tags));
            }

            var tagVM = new Tag
            {
                Tags = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Guestbooks = await data.ToListAsync()
            };

            return View(tagVM);
        }

        // Test if posting is right working
        [HttpPost, ActionName("Index")]
        public string Index(string str_search, bool isUsed = false)
        {
            return "From [HttpPost]Index: filter on " + str_search;
        }

        // GET: Guestbooks/Details/5
        [HttpGet, ActionName("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbook = await _context.Guestbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestbook == null)
            {
                return NotFound();
            }

            return View(guestbook);
        }

        // GET: Guestbooks/Create
        [HttpGet, ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guestbooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Comment,Date,Tag")] Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                guestbook.Date = DateTime.Now.Date;
                _context.Add(guestbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestbook);
        }

        // GET: Guestbooks/Edit/5
        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbook = await _context.Guestbook.FindAsync(id);
            if (guestbook == null)
            {
                return NotFound();
            }
            return View(guestbook);
        }

        // POST: Guestbooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Comment,Date,Tag")] Guestbook guestbook)
        {
            if (id != guestbook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    guestbook.Date = DateTime.Now.Date;
                    _context.Update(guestbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestbookExists(guestbook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guestbook);
        }

        // GET: Guestbooks/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbook = await _context.Guestbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestbook == null)
            {
                return NotFound();
            }

            return View(guestbook);
        }

        // POST: Guestbooks/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestbook = await _context.Guestbook.FindAsync(id);
            _context.Guestbook.Remove(guestbook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestbookExists(int id)
        {
            return _context.Guestbook.Any(e => e.Id == id);
        }
    }
}
