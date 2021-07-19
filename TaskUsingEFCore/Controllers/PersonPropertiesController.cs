using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskUsingEFCore.Models;

namespace TaskUsingEFCore.Controllers
{
    public class PersonPropertiesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PersonPropertiesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PersonProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.personProperties.ToListAsync());
        }

        // GET: PersonProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personProperty = await _context.personProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personProperty == null)
            {
                return NotFound();
            }

            return View(personProperty);
        }

        // GET: PersonProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonName,PersonEmail,PersonPlan,PersonBillingIntervel,PersonStreetAddress,PersonCity,PersonPhoneNumber,PersonState,PersonPostalCode,PersonCountry,PersonOldPassword,PersonNewPassword")] PersonProperty personProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personProperty);
        }

        // GET: PersonProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personProperty = await _context.personProperties.FindAsync(id);
            if (personProperty == null)
            {
                return NotFound();
            }
            return View(personProperty);
        }

        // POST: PersonProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonName,PersonEmail,PersonPlan,PersonBillingIntervel,PersonStreetAddress,PersonCity,PersonPhoneNumber,PersonState,PersonPostalCode,PersonCountry,PersonOldPassword,PersonNewPassword")] PersonProperty personProperty)
        {
            if (id != personProperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonPropertyExists(personProperty.Id))
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
            return View(personProperty);
        }

        // GET: PersonProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personProperty = await _context.personProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personProperty == null)
            {
                return NotFound();
            }

            return View(personProperty);
        }

        // POST: PersonProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personProperty = await _context.personProperties.FindAsync(id);
            _context.personProperties.Remove(personProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonPropertyExists(int id)
        {
            return _context.personProperties.Any(e => e.Id == id);
        }
    }
}
