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
    public class ModelsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var models = _unitOfWork.ModelsRepository.GetAll();
            foreach (var model in models)
            {
                model.Manufacturer = await _unitOfWork.ManufacturersRepository.GetByIdAsync(model.ManufacturerId) ??
                    new Manufacturer();
            }
            return View(models);
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _unitOfWork.ModelsRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            model.Manufacturer = await _unitOfWork.ManufacturersRepository.GetByIdAsync(model.ManufacturerId) ??
                new Manufacturer();

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(
                _unitOfWork.ManufacturersRepository.GetAll(), "Id", "Title");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerId,Title")] Model model)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ModelsRepository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(
                _unitOfWork.ManufacturersRepository.GetAll(), "Id", "Title", model.ManufacturerId);
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _unitOfWork.ModelsRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(
                _unitOfWork.ManufacturersRepository.GetAll(), "Id", "Title", model.ManufacturerId);
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerId,Title")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.ModelsRepository.Update(model);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(
                _unitOfWork.ManufacturersRepository.GetAll(), "Id", "Title", model.ManufacturerId);
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _unitOfWork.ModelsRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            model.Manufacturer = await _unitOfWork.ManufacturersRepository.GetByIdAsync(model.ManufacturerId) ??
                new Manufacturer();

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _unitOfWork.ModelsRepository.GetByIdAsync(id);
            if (model != null)
            {
                await _unitOfWork.ModelsRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
