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

namespace Autopark.WEB.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "admin")]
    public class GenerationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenerationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Generations
        public async Task<IActionResult> Index()
        {
            var generations = _unitOfWork.GenerationsRepository.GetAll();
            foreach (var generation in generations)
            {
                generation.Model = await _unitOfWork.ModelsRepository.
                    GetByIdAsync(generation.ModelId);
                if (!ReferenceEquals(generation.Model, null))
                {
                    generation.Model.Manufacturer = await _unitOfWork.ManufacturersRepository.
                        GetByIdAsync(generation.Model.ManufacturerId);
                }
            }

            return View(generations);
        }

        // GET: Generations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generation = await _unitOfWork.GenerationsRepository.GetByIdAsync(id.Value);
            if (generation == null)
            {
                return NotFound();
            }
            generation.Model = await _unitOfWork.ModelsRepository.GetByIdAsync(generation.ModelId);
            if (generation.Model != null)
            {
                generation.Model.Manufacturer = await _unitOfWork.ManufacturersRepository.
                    GetByIdAsync(generation.Model.ManufacturerId);
            }

            return View(generation);
        }

        // GET: Generations/Create
        public async Task<IActionResult> Create()
        {
            var models = _unitOfWork.ModelsRepository.GetAll();
            Manufacturer? manufacturer;
            foreach (var model in models)
            {
                manufacturer = await _unitOfWork.ManufacturersRepository.
                    GetByIdAsync(model.ManufacturerId);
                if (!ReferenceEquals(manufacturer, null))
                {
                    model.Title = manufacturer.Title + " " + model.Title;
                }
            }
            ViewData["ModelId"] = new SelectList(models, "Id", "Title");
            return View();
        }

        // POST: Generations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,Title")] Generation generation)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GenerationsRepository.Create(generation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(
                _unitOfWork.ModelsRepository.GetAll(), "Id", "Title", generation.ModelId);
            return View(generation);
        }

        // GET: Generations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generation = await _unitOfWork.GenerationsRepository.GetByIdAsync(id.Value);
            if (generation == null)
            {
                return NotFound();
            }

            var models = _unitOfWork.ModelsRepository.GetAll();
            Manufacturer? manufacturer;
            foreach (var model in models)
            {
                manufacturer = await _unitOfWork.ManufacturersRepository.
                    GetByIdAsync(model.ManufacturerId);
                if (!ReferenceEquals(manufacturer, null))
                {
                    model.Title = manufacturer.Title + " " + model.Title;
                }
            }
            ViewData["ModelId"] = new SelectList(models, "Id", "Title", generation.ModelId);
            return View(generation);
        }

        // POST: Generations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,Title")] Generation generation)
        {
            if (id != generation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.GenerationsRepository.Update(generation);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(
                _unitOfWork.ModelsRepository.GetAll(), "Id", "Title", generation.ModelId);
            return View(generation);
        }

        // GET: Generations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generation = await _unitOfWork.GenerationsRepository.GetByIdAsync(id.Value);
            if (generation == null)
            {
                return NotFound();
            }
            generation.Model = await _unitOfWork.ModelsRepository.GetByIdAsync(generation.ModelId);
            if (generation.Model != null)
            {
                generation.Model.Manufacturer = await _unitOfWork.ManufacturersRepository.
                    GetByIdAsync(generation.Model.ManufacturerId);
            }

            return View(generation);
        }

        // POST: Generations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generation = await _unitOfWork.GenerationsRepository.GetByIdAsync(id);
            if (generation != null)
            {
                await _unitOfWork.GenerationsRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
