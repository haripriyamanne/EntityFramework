using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskUsingEFCore.Models;

namespace TaskUsingEFCore.Controllers
{
    public class CountryTableController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CountryTableController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.countryTables.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryTable countryTable)
        {
            if (ModelState.IsValid)
            {
                _db.Add(countryTable);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryTable);
        }
        public IActionResult Demo()
        {
            List<CountryTable> countryTable = new List<CountryTable>();
            countryTable = (from country in _db.countryTables select country).ToList();
            countryTable.Insert(0, new CountryTable { CountryId = 0,CountryName="select" });
            ViewBag.ListOfCountrys = countryTable;
            return View();
        }
    }
}
