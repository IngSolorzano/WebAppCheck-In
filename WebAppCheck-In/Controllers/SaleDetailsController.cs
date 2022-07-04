using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCheck_In.Models;

namespace WebAppCheck_In.Controllers
{
    public class SaleDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public SaleDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SaleDetails
        public async Task<IActionResult> Index()
        {
              return _context.SaleDetails != null ? 
                          View(await _context.SaleDetails.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SaleDetails'  is null.");
        }

        // GET: SaleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetails.FindAsync(id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            return View(saleDetail);
        }

        // POST: SaleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaleDetail saleDetail)
        {
            if (id != saleDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleDetailExists(saleDetail.Id))
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
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaleDetails == null)
            {
                return Problem("Entity set 'AppDbContext.SaleDetails'  is null.");
            }
            var saleDetail = await _context.SaleDetails.FindAsync(id);
            if (saleDetail != null)
            {
                _context.SaleDetails.Remove(saleDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleDetailExists(int id)
        {
          return (_context.SaleDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
