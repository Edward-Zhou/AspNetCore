using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCorePro.Data;
using EFCorePro.Models.ManyToMany;
using AutoMapper;
using Newtonsoft.Json;

namespace EFCorePro.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;

        public ArticlesController(ApplicationDbContext context
            //, IMapper mapper
            )
        {
            _context = context;
           // _mapper = mapper;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<IActionResult> GetAllArticleAsync()
        {
            var articles = await _context.Articles
                                   .Include(a => a.ArticleTags)
                                   .ThenInclude(at => at.Tag)
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       ArticleName = a.ArticleName,
                                       Tags = a.ArticleTags.Select(at => at.Tag).ToList()
                                   })
                                   .ToListAsync();
            return Ok(articles);
        }
        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var article1 = _context.Articles.Include(a => a.ArticleName == "A1")
            //                                .SingleOrDefault();
            var article = _context.Articles
                                  .Include(a => a.ArticleTags).ThenInclude(at => at.Tag)
                                  .FirstOrDefault(a => a.Id == id);

            return Ok(Mapper.Map<ArticleViewModel>(article));
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var article = await _context.Articles
            //    .SingleOrDefaultAsync(m => m.Id == id);
            //if (article == null)
            //{
            //    return NotFound();
            //}

            //return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArticleName")] Article article)
        {
            if (ModelState.IsValid)
            {
                var newSerialInfo = new Article();
                string values = JsonConvert.SerializeObject(new Article { ArticleName = "TT" });
                JsonConvert.PopulateObject(values, newSerialInfo);
                _context.Add(newSerialInfo);
                newSerialInfo.Id = 0;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArticleName")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.Id == id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
