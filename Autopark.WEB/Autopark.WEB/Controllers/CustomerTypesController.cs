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

    [Authorize(Roles = "admin")]
    public class CustomerTypesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CustomerTypes
        public IActionResult Index()
        {
              return View(_unitOfWork.CustomerTypesRepository.GetAll());
        }

        // GET: CustomerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _unitOfWork.CustomerTypesRepository.
                GetByIdAsync(id.Value);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // GET: CustomerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CustomerTypesRepository.Create(customerType);
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _unitOfWork.CustomerTypesRepository.
                GetByIdAsync(id.Value);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CustomerType customerType)
        {
            if (id != customerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.CustomerTypesRepository.Update(customerType);
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _unitOfWork.CustomerTypesRepository.
                GetByIdAsync(id.Value);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerType = await _unitOfWork.CustomerTypesRepository.
                GetByIdAsync(id);
            if (customerType != null)
            {
                await _unitOfWork.CustomerTypesRepository.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
