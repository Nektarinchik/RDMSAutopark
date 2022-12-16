using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autopark.DAL.EF;
using Autopark.WEB.Entities;
using Autopark.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Autopark.WEB.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "admin")]
    public class CarTypesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CarTypes
        public IActionResult Index()
        {
            return View(_unitOfWork.CarTypesRepository.GetAll());
        }

        // GET: CarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _unitOfWork.CarTypesRepository.GetByIdAsync(id.Value);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // GET: CarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CarTypesRepository.Create(carType);
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: CarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _unitOfWork.CarTypesRepository.GetByIdAsync(id.Value);
            if (carType == null)
            {
                return NotFound();
            }
            return View(carType);
        }

        // POST: CarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CarType carType)
        {
            if (id != carType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.CarTypesRepository.Update(carType);
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: CarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _unitOfWork.CarTypesRepository.GetByIdAsync(id.Value);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // POST: CarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carType = await _unitOfWork.CarTypesRepository.GetByIdAsync(id);
            if (carType != null)
            {
                await _unitOfWork.CarTypesRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
