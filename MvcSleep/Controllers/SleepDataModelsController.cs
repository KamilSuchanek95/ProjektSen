using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSleep.Data;
using MvcSleep.Models;

namespace MvcSleep.Controllers
{
    public class SleepDataModelsController : Controller
    {
        private readonly MvcSleepDataContext _context;

        public SleepDataModelsController(MvcSleepDataContext context)
        {
            _context = context;
        }

        // GET: SleepDataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SleepData.ToListAsync());
        }

        // GET: SleepDataModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepDataModel = await _context.SleepData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepDataModel == null)
            {
                return NotFound();
            }

            return View(sleepDataModel);
        }

        // GET: SleepDataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SleepDataModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SleepDataName,SleepDataAnnotation")] SleepDataModel sleepDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleepDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sleepDataModel);
        }

        // GET: SleepDataModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepDataModel = await _context.SleepData.FindAsync(id);
            if (sleepDataModel == null)
            {
                return NotFound();
            }
            return View(sleepDataModel);
        }

        // POST: SleepDataModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SleepDataName,SleepDataAnnotation")] SleepDataModel sleepDataModel)
        {
            if (id != sleepDataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleepDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleepDataModelExists(sleepDataModel.Id))
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
            return View(sleepDataModel);
        }

        // GET: SleepDataModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepDataModel = await _context.SleepData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepDataModel == null)
            {
                return NotFound();
            }

            return View(sleepDataModel);
        }

        // POST: SleepDataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleepDataModel = await _context.SleepData.FindAsync(id);
            _context.SleepData.Remove(sleepDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleepDataModelExists(int id)
        {
            return _context.SleepData.Any(e => e.Id == id);
        }
    }
}
