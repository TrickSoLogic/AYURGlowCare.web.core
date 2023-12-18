using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AYURGlowCare.web.core.Data;
using AYURGlowCare.web.core.Models;

namespace AYURGlowCare.web.core.Controllers
{
    public class ordersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ordersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: orders
        public async Task<IActionResult> Index()
        {
              return _context.order != null ? 
                          View(await _context.order.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.order'  is null.");
        }

        // GET: orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.order == null)
            {
                return NotFound();
            }

            var order = await _context.order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,OrderDate,TotalAmount")] order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.order == null)
            {
                return NotFound();
            }

            var order = await _context.order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,OrderDate,TotalAmount")] order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!orderExists(order.Id))
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
            return View(order);
        }

        // GET: orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.order == null)
            {
                return NotFound();
            }

            var order = await _context.order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.order == null)
            {
                return Problem("Entity set 'ApplicationDbContext.order'  is null.");
            }
            var order = await _context.order.FindAsync(id);
            if (order != null)
            {
                _context.order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool orderExists(int id)
        {
          return (_context.order?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
