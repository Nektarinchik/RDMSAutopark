using Autopark.DAL.EF;
using Autopark.DAL.Entities;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Autopark.WEB.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        private readonly RdbmsdbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeesController(
            UserManager<ApplicationUser> userManager, 
            RdbmsdbContext context, 
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Users
                .Join(
                    _context.UserRoles,
                    u => u.Id,
                    ur => ur.UserId,
                    (u, ur) => new {u, ur})
                .Join(
                    _context.Roles,
                    uur => uur.ur.RoleId,
                    r => r.Id,
                    (uur, r) => new {uur, r})
                .Where(resultSet => resultSet.r.Name == "EMPLOYEE")
                .Select(resultSet => resultSet.uur.u));
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(
                _unitOfWork.VCustomersRepository.GetAll(), "Id", "CustomerName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId")] CreateEmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == employeeViewModel.CustomerId);
                if (user != null)
                {
                    user.StartDate = DateTime.Now;
                    user.EndDate = null;
                    await _userManager.AddToRoleAsync(user, "employee");
                    await _context.SaveChangesAsync();
                }
                return Redirect(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(
                _unitOfWork.VCustomersRepository.GetAll(), "Id", "CustomerName", employeeViewModel.CustomerId);
            return View(employeeViewModel);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Users.FirstOrDefault(u => u.Id == id);
            
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.EndDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
