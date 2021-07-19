using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskUsingEFCore.Models;

namespace TaskUsingEFCore.Controllers
{
    public class StateController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StateController(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.states.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (ModelState.IsValid)
            {
                _db.Add(state);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(state);
        }
    }
}
