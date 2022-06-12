using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using MyBiz.Models;
using System.Linq;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _context.Services.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service srvc)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(srvc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var data = _context.Services.FirstOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Service srvc)
        {
            if (ModelState.IsValid)
            {
                var existsData = _context.Services.FirstOrDefault(x => x.Id == srvc.Id);
                existsData.Name = srvc.Name;
                existsData.Desc = srvc.Desc;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Services.FirstOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Service srvc)
        {
            var existsData = _context.Services.FirstOrDefault(x => x.Id == srvc.Id);
            _context.Services.Remove(existsData);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
