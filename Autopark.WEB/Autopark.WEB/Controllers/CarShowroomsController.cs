using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autopark.DAL.EF;
using Autopark.WEB.Entities;
using Autopark.DAL.Interfaces;

namespace Autopark.WEB.Controllers
{
    public class CarShowroomsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarShowroomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CarShowrooms
        public IActionResult Index()
        {
              return View(_carShowroomsRepository.GetAll());
        }

        // GET: CarShowrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carShowroom = await _carShowroomsRepository.GetByIdAsync(id.Value);
            if (carShowroom == null)
            {
                return NotFound();
            }

            return View(carShowroom);
        }

        // GET: CarShowrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarShowrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Rating,Phone")] CarShowroom carShowroom)
        {
            if (ModelState.IsValid)
            {
                _carShowroomsRepository.Create(carShowroom);
                await
                //_context.Add(carShowroom);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(carShowroom);
        }

        // GET: CarShowrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarShowrooms == null)
            {
                return NotFound();
            }

            var carShowroom = await _context.CarShowrooms.FindAsync(id);
            if (carShowroom == null)
            {
                return NotFound();
            }
            return View(carShowroom);
        }

        // POST: CarShowrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Rating,Phone")] CarShowroom carShowroom)
        {
            if (id != carShowroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carShowroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarShowroomExists(carShowroom.Id))
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
            return View(carShowroom);
        }

        // GET: CarShowrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarShowrooms == null)
            {
                return NotFound();
            }

            var carShowroom = await _context.CarShowrooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carShowroom == null)
            {
                return NotFound();
            }

            return View(carShowroom);
        }

        // POST: CarShowrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarShowrooms == null)
            {
                return Problem("Entity set 'RdbmsdbContext.CarShowrooms'  is null.");
            }
            var carShowroom = await _context.CarShowrooms.FindAsync(id);
            if (carShowroom != null)
            {
                _context.CarShowrooms.Remove(carShowroom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarShowroomExists(int id)
        {
          return _context.CarShowrooms.Any(e => e.Id == id);
        }
    }
}
