using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using MyBiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Positions.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position pos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var data=_context.Positions.Any(x=>x.Name == pos.Name);
            if (!data)
            {
                _context.Positions.Add(pos);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Edit(int id)
        {
            var data = _context.Positions.FirstOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Position pos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var existsData = _context.Positions.FirstOrDefault(x => x.Id==pos.Id);
            existsData.Name = pos.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Positions.FirstOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Position pos)
        {
            var existsData = _context.Positions.FirstOrDefault(x => x.Id == pos.Id);
            _context.Positions.Remove(existsData);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
