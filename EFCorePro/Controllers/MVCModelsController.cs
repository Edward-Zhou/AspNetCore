using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCorePro.Data;
using EFCorePro.Models.MVCModel;

namespace EFCorePro.Controllers
{
    public class MVCModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MVCModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MVCModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MVCModel.ToListAsync());
        }

        // GET: MVCModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCModel = await _context.MVCModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVCModel == null)
            {
                return NotFound();
            }

            return View(mVCModel);
        }

        // GET: MVCModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVCModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoInvoAb,CreationDate")] MVCModel mVCModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mVCModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mVCModel);
        }

        // GET: MVCModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCModel = await _context.MVCModel.FindAsync(id);
            if (mVCModel == null)
            {
                return NotFound();
            }
            return View(mVCModel);
        }

        // POST: MVCModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoInvoAb,CreationDate")] MVCModel mVCModel)
        {
            return View(mVCModel);

            if (id != mVCModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mVCModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MVCModelExists(mVCModel.Id))
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
            return View(mVCModel);
        }

        // GET: MVCModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCModel = await _context.MVCModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVCModel == null)
            {
                return NotFound();
            }

            return View(mVCModel);
        }

        // POST: MVCModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mVCModel = await _context.MVCModel.FindAsync(id);
            _context.MVCModel.Remove(mVCModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MVCModelExists(int id)
        {
            return _context.MVCModel.Any(e => e.Id == id);
        }
    }
}
