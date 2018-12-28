using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPro.Models;
using AutoMapperPro.Models.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperPro.Controllers
{
    public class AutoMapperController : Controller
    {
        private readonly IMapper _mapper;
        public AutoMapperController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void IgnoreId()
        {
            Order user = new Order { Id = 1, Name = "T1" };
            Order newUser = _mapper.Map<Order>(user);
        }
        // GET: AutoMapper
        public ActionResult Index()
        {
            OrderViewModel orderViewModel = new OrderViewModel {
                Id = 1,
                Name = "O1",
                OrderItemViewModel = new List<OrderItemViewModel>() {
                    new OrderItemViewModel{ Id = 1, Name = "OI1", OrderViewModelId = 1 },
                    new OrderItemViewModel{ Id = 2, Name = "OI2", OrderViewModelId = 1 }
                }
            };
            Order model = new Order();
            var result = _mapper.Map(orderViewModel, model);
            return View();
        }

        // GET: AutoMapper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutoMapper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoMapper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutoMapper/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutoMapper/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutoMapper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutoMapper/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public void AddMovie(MovieDto movie)
        {
            //execption here
            var movieDM = _mapper.Map<Movie>(movie);
        }
    }
}