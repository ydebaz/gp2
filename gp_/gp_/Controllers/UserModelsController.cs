using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gp_.Data;
using gp_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace gp_.Controllers
{
   
    public class UserModelsController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private SignInManager<IdentityUser> _signInManager;


        public UserModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> sm)
        {
            _context = context; _userManager = userManager;
            _signInManager = sm;
        }

        // GET: UserModels
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Index()
        {
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return View(_context.user.FirstOrDefault(m => m.Id == id));
           // return View(await _context.user.ToListAsync());
        }
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Index(string id)
        {
           // var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return View(_context.user.FirstOrDefault(m => m.Id ==Guid.Parse( id)));
            // return View(await _context.user.ToListAsync());
        }
        // GET: UserModels/Details/5
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
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
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "patient,doctor")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userModel = await _context.user.FindAsync(id);
            _context.user.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(Guid id)
        {
            return _context.user.Any(e => e.Id == id);
        }
    }
}
