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
using Autopark.WEB.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;

namespace Autopark.WEB.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles ="admin, employee, customer")]
        // GET: Cars
        public IActionResult Index()
        {
            List<IndexDetailCarsViewModel> carsViewModelList = new List<IndexDetailCarsViewModel>();
            var cars = _unitOfWork.CarsRepository.GetAll();
            foreach (var car in cars)
            {
                carsViewModelList.Add(new IndexDetailCarsViewModel(
                    _unitOfWork, car));
            }
            return View(carsViewModelList);
        }

        [Authorize(Roles = "admin, employee, customer")]

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.CarsRepository.GetByIdAsync(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            IndexDetailCarsViewModel idcvm = new IndexDetailCarsViewModel(
                _unitOfWork, 
                car);

            return View(idcvm);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: Cars/Create
        public IActionResult Create()
        {
            CreateUpdateCarsViewModel createCarsViewModel = new CreateUpdateCarsViewModel(_unitOfWork);
            ViewData["CarShowroomId"] = new SelectList(
                createCarsViewModel.CarShowrooms, "Id", "Title");
            ViewData["CarTypeId"] = new SelectList(
                createCarsViewModel.CarTypes, "Id", "Title");
            ViewData["GenerationId"] = new SelectList(
                createCarsViewModel.Generations, "Id", "Title");
            return View();
        }

        [Authorize(Roles = "admin, employee")]

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarTypeId,CarShowroomId,GenerationId,Price,Vin")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CarsRepository.Create(car);
                return RedirectToAction(nameof(Index));
            }
            CreateUpdateCarsViewModel createCarsViewModel = new CreateUpdateCarsViewModel(_unitOfWork);
            ViewData["CarShowroomId"] = new SelectList(
                createCarsViewModel.CarShowrooms, "Id", "Title", car.CarShowroomId);
            ViewData["CarTypeId"] = new SelectList(
                createCarsViewModel.CarTypes, "Id", "Title", car.CarTypeId);
            ViewData["GenerationId"] = new SelectList(
                createCarsViewModel.Generations, "Id", "Title", car.GenerationId);
            return View(car);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.CarsRepository.GetByIdAsync(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            CreateUpdateCarsViewModel updateCarViewModel = new CreateUpdateCarsViewModel(_unitOfWork);
            ViewData["CarShowroomId"] = new SelectList(
                updateCarViewModel.CarShowrooms, "Id", "Title", car.CarShowroomId);
            ViewData["CarTypeId"] = new SelectList(
                updateCarViewModel.CarTypes, "Id", "Title", car.CarTypeId);
            ViewData["GenerationId"] = new SelectList(
                updateCarViewModel.Generations, "Id", "Title", car.GenerationId);
            return View(car);
        }

        [Authorize(Roles = "admin, employee")]

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarTypeId,CarShowroomId,GenerationId,Price,Vin")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.CarsRepository.Update(car);
                return RedirectToAction(nameof(Index));
            }

            CreateUpdateCarsViewModel updateCarsViewModel = new CreateUpdateCarsViewModel(_unitOfWork);
            ViewData["CarShowroomId"] = new SelectList(
                updateCarsViewModel.CarShowrooms, "Id", "Title", car.CarShowroomId);
            ViewData["CarTypeId"] = new SelectList(
                updateCarsViewModel.CarTypes, "Id", "Title", car.CarTypeId);
            ViewData["GenerationId"] = new SelectList(
                updateCarsViewModel.Generations, "Id", "Title", car.GenerationId);
            return View(car);
        }

        [Authorize(Roles = "admin, employee")]

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.CarsRepository.GetByIdAsync(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            IndexDetailCarsViewModel deleteCarsViewModel = new IndexDetailCarsViewModel(
                _unitOfWork,
                car);

            return View(deleteCarsViewModel);
        }

        [Authorize(Roles = "admin, employee")]

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _unitOfWork.CarsRepository.GetByIdAsync(id);
            if (car != null)
            {
                await _unitOfWork.CarsRepository.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
