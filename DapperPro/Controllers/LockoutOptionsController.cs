using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DapperPro.Data;
using DapperPro.Models.IdentityOption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using DapperPro.Extensions;

namespace DapperPro.Controllers
{
    public class LockoutOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IdentityOptions _identityOptions;
        private readonly ISecuritySettingService _securitySettingService;
        public LockoutOptionsController(ApplicationDbContext context
            , IOptions<IdentityOptions> identityOptions
            , ISecuritySettingService securitySettingService)
        {
            _context = context;
            _identityOptions = identityOptions.Value;
            _securitySettingService = securitySettingService;
        }

        // GET: LockoutOptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.LockoutOption.ToListAsync());
        }

        // GET: LockoutOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lockout = _identityOptions.Lockout;
            var lockoutOption = await _context.LockoutOption
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lockoutOption == null)
            {
                return NotFound();
            }
            return View(lockoutOption);
        }

        // GET: LockoutOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LockoutOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AllowedForNewUsers,MaxFailedAccessAttempts,DefaultLockoutTimeSpan")] LockoutOption lockoutOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lockoutOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lockoutOption);
        }

        // GET: LockoutOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lockoutOption = await _context.LockoutOption.SingleOrDefaultAsync(m => m.Id == id);
            if (lockoutOption == null)
            {
                return NotFound();
            }
            return View(lockoutOption);
        }

        // POST: LockoutOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AllowedForNewUsers,MaxFailedAccessAttempts,DefaultLockoutTimeSpan")] LockoutOption lockoutOption)
        {
            _securitySettingService.UpdateSecuritySetting(lockoutOption);
            //if (id != lockoutOption.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(lockoutOption);
            //        await _context.SaveChangesAsync();
            //        //_identityOptions.Lockout.MaxFailedAccessAttempts = lockoutOption.MaxFailedAccessAttempts;
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!LockoutOptionExists(lockoutOption.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(lockoutOption);
        }

        // GET: LockoutOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lockoutOption = await _context.LockoutOption
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lockoutOption == null)
            {
                return NotFound();
            }

            return View(lockoutOption);
        }

        // POST: LockoutOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lockoutOption = await _context.LockoutOption.SingleOrDefaultAsync(m => m.Id == id);
            _context.LockoutOption.Remove(lockoutOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LockoutOptionExists(int id)
        {
            return _context.LockoutOption.Any(e => e.Id == id);
        }
    }
}
