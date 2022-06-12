using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.TeamMember=_context.TeamMembers.Include(x=>x.Position).ToList();
            ViewBag.Portfolio=_context.Portfolios.Include(x=>x.Catagories).ToList();
            ViewBag.Service=_context.Services.ToList();
            return View();
        }
    }
}
