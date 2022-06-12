using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using MyBiz.Helpers;
using MyBiz.Models;
using System.Linq;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PortfolioController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _context.Portfolios.Include(x => x.Catagories).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {

            ViewBag.Catagories = _context.Catagories.ToList();
            if (ModelState.IsValid)
            {
                var imageName = FileManager.Save(_env.WebRootPath, "uploads/portfolio", portfolio.PortfolioImage);
                portfolio.Image = imageName;
                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            var data = _context.Portfolios.FirstOrDefault(x=>x.Id==Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Portfolio prtf)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            if (ModelState.IsValid)
            {
                var existsData = _context.Portfolios.FirstOrDefault(x => x.Id == prtf.Id);
                if (existsData.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/portfolio", existsData.Image);
                }
                existsData.Image = FileManager.Save(_env.WebRootPath, "uploads/portfolio", prtf.PortfolioImage);
                existsData.Name = prtf.Name;
                existsData.Desc = prtf.Desc;
                existsData.CatagoryId = prtf.CatagoryId;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            var data = _context.Portfolios.FirstOrDefault(x => x.Id == Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Portfolio prtf)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            var existsData = _context.Portfolios.FirstOrDefault(x => x.Id == prtf.Id);
            FileManager.Delete(_env.WebRootPath, "uploads/portfolio", existsData.Image);
            _context.Portfolios.Remove(existsData);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
