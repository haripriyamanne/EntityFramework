﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeProject.Models;

namespace EmployeeProject.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EmployeeDetailsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: EmployeeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDetails.ToListAsync());
        }

        // GET: EmployeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,City,State,PostalCode,JobID")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,City,State,PostalCode,JobID")] EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailsExists(employeeDetails.ID))
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
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            _context.EmployeeDetails.Remove(employeeDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailsExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.ID == id);
        }
    }
}
