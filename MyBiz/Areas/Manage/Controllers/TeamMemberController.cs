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
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamMemberController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _context.TeamMembers.Include(x => x.Position).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.TeamMember = _context.TeamMembers.ToList();
            ViewBag.Position = _context.Positions.ToList();
            return View();

        }
        [HttpPost]
        public IActionResult Create(TeamMember TM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TeamMember = _context.TeamMembers.ToList();
                ViewBag.Position = _context.Positions.ToList();
                return View();
            }
            else
            {
                TM.Image=FileManager.Save(_env.WebRootPath, "Uploads/TeamMember", TM.MemberImage);
                _context.TeamMembers.Add(TM);
                _context.SaveChanges();
                return RedirectToAction("index");
                }
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.TeamMember = _context.TeamMembers.ToList();
            ViewBag.Position = _context.Positions.ToList();
            var data = _context.TeamMembers.FirstOrDefault(x => x.Id == Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(TeamMember TM)
        {
            ViewBag.TeamMember = _context.TeamMembers.ToList();
            ViewBag.Position = _context.Positions.ToList();
            var existsTM=_context.TeamMembers.FirstOrDefault(x => x.Id == TM.Id);
            if (ModelState.IsValid)
            {
                if (TM.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/teamMember", existsTM.Image);
                    TM.Image = FileManager.Save(_env.WebRootPath, "uploads/teammember", TM.MemberImage);
                }
                else
                {
                    TM.Image = FileManager.Save(_env.WebRootPath, "uploads/teamMember", TM.MemberImage);
                }
                var data = _context.TeamMembers.FirstOrDefault(x => x.Id == TM.Id);
                data.Fullname = TM.Fullname;
                data.PositionId = TM.PositionId;
                data.Desc = TM.Desc;
                data.Image= TM.Image;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.TeamMember = _context.TeamMembers.ToList();
                ViewBag.Position = _context.Positions.ToList();
                return View();
            }
        }
        public IActionResult Delete(int Id)
        {
            var data = _context.TeamMembers.Include(x=>x.Position).FirstOrDefault(x => x.Id == Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(TeamMember TM)
        {
            var existsData = _context.TeamMembers.FirstOrDefault(x => x.Id == TM.Id);
            _context.TeamMembers.Remove(existsData);
            _context.SaveChanges();
            return RedirectToAction("index","TeamMember");
        }

    }
}
