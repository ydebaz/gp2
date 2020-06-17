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
        public async Task<IActionResult> Index(string? id)
        {
            
            if (id==null ){
                var id2 = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                return View( _context.user.Find( id2));
            }
            else { 
            // var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return View( _context.user.Find(Guid.Parse(id)));
            // return View(await _context.user.ToListAsync());
       } 
        }
        // GET: UserModels/Details/5
       // [Authorize(Roles = "patient,doctor")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
               
                return NotFound("1");
            }

            var userModel = _context.user
                .Find( id);
            if (userModel == null)
            {
                //Console.WriteLine(2);

                return NotFound("2");
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
        public async Task<IActionResult> Create1([Bind("Id,FirstName,LastName")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                _context.user.Add(userModel);
                _context.SaveChanges();
              //  _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
      
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = _context.user.Find(id);
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
       // [Authorize(Roles = "patient,doctor")]
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
                    _context.user.Update(userModel);
                   _context.SaveChanges();
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

            var userModel =  _context.user
                .Find(id);
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
            var userModel =  _context.user.Find(id);
            _context.user.Remove(userModel);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(Guid id)
        {
            return _context.user.Any(e => e.Id == id);
        }
    }
}
