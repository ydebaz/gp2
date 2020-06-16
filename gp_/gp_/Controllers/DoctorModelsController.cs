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
   
    public class DoctorModelsController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private SignInManager<IdentityUser> _signInManager;

        public DoctorModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser>sm)
        {
            _context = context; _userManager = userManager;_signInManager = sm;
        }

        // GET: DoctorModels

        public IActionResult Index()
        {
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return View(_context.doctor.FirstOrDefault(m => m.Id == id));
        }

        // GET: DoctorModels/Details/5

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel =  _context.doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // GET: DoctorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("Id,FirstName,LastName,graduation_uni,workplace,status,personalphonenumber,workphonenumber,jma_number")] DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                doctorModel.ispart1comp = true;
                doctorModel.isActivated = false;
                doctorModel.Id =Guid.Parse( _userManager.GetUserId(HttpContext.User));
                _context.doctor.Add(doctorModel);
                _context.SaveChangesAsync();
               // _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorModel);
        }

        // GET: DoctorModels/Edit/5
       
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel =  _context.doctor.FindAsync(id);
            if (doctorModel == null)
            {
                return NotFound();
            }
            return View(doctorModel);
        }

        // POST: DoctorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,graduation_uni,isActivated,workplace,status,personalphonenumber,workphonenumber,ispart1comp,jma_number")] DoctorModel doctorModel)
        {
            if (id != doctorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorModel);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorModelExists(doctorModel.Id))
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
            return View(doctorModel);
        }

        // GET: DoctorModels/Delete/5
      
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctor
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // POST: DoctorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doctorModel = await _context.doctor.FindAsync(id).ConfigureAwait(true);
            _context.doctor.Remove(doctorModel);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorModelExists(Guid id)
        {
            return _context.doctor.Any(e => e.Id == id);
        }
    }
}
