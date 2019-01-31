using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class ModelController : Controller
    {
        private readonly MVCProContext _db;
        public ModelController(MVCProContext db)
        {
            _db = db;
        }
        public IActionResult Index(String SearchString, Classification DateValueSign)
        {


            var query = from r in _db.Books select r;

            if (SearchString != null && SearchString != "")
            {
                query = query.Where(x => x.Title.Contains(SearchString));

            }
            switch (DateValueSign)
            {
                case Classification.NewestFirst:
                    query = query.OrderByDescending(x => x.PublicationDate);
                    break;
                case Classification.OldestFirst:
                    query = query.OrderBy(x => x.PublicationDate);
                    break;
                case Classification.MostPopular:
                    query = query.OrderByDescending(x => x.AverageRating);
                    break;
                case Classification.LeastPopular:
                    query = query.OrderBy(x => x.AverageRating);
                    break;
            }
            List<Book> SelectedBooks = new List<Book>();
            SelectedBooks = query.ToList();
            ViewBag.SelectedBooks = SelectedBooks.Count();
            ViewBag.TotalBooks = _db.Books.Count();

            return View(SelectedBooks);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var model = new MVCModel { NoInvoAb = 2 };
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Update()
        {
            var model = new MVCModel
            {
                NoInvoAb = 5
                ,
                CreationDate = DateTime.Now
                ,
                MVCSubModel = new MVCSubModel
                {
                    Name = "MVCSubModel"
                }
            };
            var result = model.CreationDate.Value.ToString("dd.MM.yyyy");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(MVCModel viewModel)
        {
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Translation()
        {
            TranslationsModel translationsModel = new TranslationsModel() { Translations = new List<Translation>() };
            translationsModel.Translations.Add(new Models.Translation { TranslationID = Guid.NewGuid(), LanguageID = Guid.NewGuid() });
            translationsModel.Translations.Add(new Models.Translation { TranslationID = Guid.NewGuid(), LanguageID = Guid.NewGuid() });
            translationsModel.Translations.Add(new Models.Translation { TranslationID = Guid.NewGuid(), LanguageID = Guid.NewGuid() });
            translationsModel.Translations.Add(new Models.Translation { TranslationID = Guid.NewGuid(), LanguageID = Guid.NewGuid() });
            return View(translationsModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MVCModel input)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTimeVM()
        {
            var vm = new TimeVM();
            var time = vm.TimeFrom.ToString("hh\\:mm");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTimeVM(TimeVM input)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult ValidationModelCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ValidationModelCreate(ValidationModel input)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpGet(nameof(Location))]
        public async Task<IActionResult> Location(LocationQueryParameters queryParams)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            return StatusCode(200);
        }
    }
}