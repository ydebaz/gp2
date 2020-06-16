using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gp_.Data;
using gp_.Models;
using Microsoft.AspNetCore.Authorization;

namespace gp_.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class admindashboard : Controller
    {
        private readonly ApplicationDbContext _context;

        public admindashboard(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admindashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.doctor.ToListAsync());
        }

        // GET: admindashboard/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // GET: admindashboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admindashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,graduation_uni,isActivated,workplace,status,personalphonenumber,workphonenumber,ispart1comp,jma_number")] DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                doctorModel.Id = Guid.NewGuid();
                _context.Add(doctorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorModel);
        }

        // GET: admindashboard/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctor.FindAsync(id);
            if (doctorModel == null)
            {
                return NotFound();
            }
            return View(doctorModel);
        }

        // POST: admindashboard/Edit/5
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
                    await _context.SaveChangesAsync();
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

        // GET: admindashboard/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // POST: admindashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doctorModel = await _context.doctor.FindAsync(id);
            _context.doctor.Remove(doctorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorModelExists(Guid id)
        {
            return _context.doctor.Any(e => e.Id == id);
        }
    }
}
