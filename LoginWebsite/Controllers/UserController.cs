using LoginWebsite.Models;
using LoginWebsite.Data;
using LoginWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LoginWebsite.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}