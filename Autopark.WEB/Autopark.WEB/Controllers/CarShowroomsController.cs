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
using Microsoft.AspNetCore.Authorization;

namespace Autopark.WEB.Controllers
{
    public class CarShowroomsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarShowroomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "admin, employee, customer")]

        // GET: CarShowrooms
        public IActionResult Index()
        {
              return View(_unitOfWork.CarShowroomsRepository.GetAll());
        }

        [Authorize(Roles = "admin, employee, customer")]
        // GET: CarShowrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carShowroom = await _unitOfWork.CarShowroomsRepository.GetByIdAsync(id.Value);
            if (carShowroom == null)
            {
                return NotFound();
            }

            return View(carShowroom);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: CarShowrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin, employee")]

        // POST: CarShowrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Rating,Phone")] CarShowroom carShowroom)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CarShowroomsRepository.Create(carShowroom);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carShowroom);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: CarShowrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carShowroom = await _unitOfWork.CarShowroomsRepository.GetByIdAsync(id.Value);
            if (carShowroom == null)
            {
                return NotFound();
            }
            return View(carShowroom);
        }

        [Authorize(Roles = "admin, employee")]

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
                await _unitOfWork.CarShowroomsRepository.Update(carShowroom);
                return RedirectToAction(nameof(Index));
            }
            return View(carShowroom);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: CarShowrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carShowroom = await _unitOfWork.CarShowroomsRepository.GetByIdAsync(id.Value);
            if (carShowroom == null)
            {
                return NotFound();
            }

            return View(carShowroom);
        }

        [Authorize(Roles = "admin, employee")]

        // POST: CarShowrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var carShowroom = await _unitOfWork.CarShowroomsRepository.GetByIdAsync(id);
            if (carShowroom != null)
            {
                await _unitOfWork.CarShowroomsRepository.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
