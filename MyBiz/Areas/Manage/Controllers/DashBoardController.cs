using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DashBoardController(AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
