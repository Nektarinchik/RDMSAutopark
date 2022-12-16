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
using Autopark.WEB.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;

namespace Autopark.WEB.Controllers
{

    [Authorize(Roles = "admin, employee")]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = _unitOfWork.VOrdersRepository.GetAll();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _unitOfWork.VOrdersRepository.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        //GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(
                _unitOfWork.VCarsRepository.GetAll(), "Id", "Title");
            ViewData["CustomerId"] = new SelectList(
                _unitOfWork.VCustomersRepository.GetAll(), "Id", "CustomerName");
            ViewData["EmployeeId"] = new SelectList(
                _unitOfWork.VEmployeesRepository.GetAll(), "Id", "EmployeeName");
            ViewData["DiscountId"] = new SelectList(
                _unitOfWork.DiscountsRepository.GetAll(), "Id", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,EmployeeId,DiscountId,CarId")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var customerEmployee = await _unitOfWork.CustomerEmployeeRepository.
                    GetByIdAsync(order.CustomerId, order.EmployeeId);
                if (ReferenceEquals(customerEmployee, null))
                {
                    await _unitOfWork.CustomerEmployeeRepository.Create(
                        new CustomerEmployee
                        {
                            CustomerId = order.CustomerId,
                            EmployeeId = order.EmployeeId,
                        });

                    customerEmployee = await _unitOfWork.CustomerEmployeeRepository.
                        GetByIdAsync(order.CustomerId, order.EmployeeId);
                }
                await _unitOfWork.OrdersRepository.Create(
                    new Order
                    {
                        CustomerEmployeeId = (customerEmployee == null ? null : customerEmployee.Id),
                        DiscountId = order.DiscountId,
                        CarId = order.CarId
                    });
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(
                _unitOfWork.VCarsRepository.GetAll(), "Id", "Title", order.CarId);
            ViewData["CustomerId"] = new SelectList(
                _unitOfWork.VCustomersRepository.GetAll(), "Id", "CustomerName", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(
                _unitOfWork.VEmployeesRepository.GetAll(), "Id", "EmployeeName", order.EmployeeId);
            ViewData["DiscountId"] = new SelectList(
                _unitOfWork.DiscountsRepository.GetAll(), "Id", "Title", order.DiscountId);
            return View(order);
        }
    }
}
