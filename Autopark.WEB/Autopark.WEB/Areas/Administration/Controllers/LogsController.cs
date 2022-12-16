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

namespace Autopark.WEB.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class LogsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var logs = _unitOfWork.LogsRepository.GetAll();
            foreach (var log in logs)
            {
                if (log.UserId.HasValue)
                {
                    log.CustomerUser = await _unitOfWork.ApplicationUserRepository.
                        GetByIdAsync(log.UserId.Value);
                }
            }
            return View(logs);
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _unitOfWork.LogsRepository.
                GetByIdAsync(id.Value);
            if (log == null)
            {
                return NotFound();
            }

            if (log.UserId.HasValue)
            {
                log.CustomerUser = await _unitOfWork.ApplicationUserRepository.
                    GetByIdAsync(log.UserId.Value);
                ViewData["UserName"] = log.CustomerUser?.UserName;
            }

            return View(log);
        }

    }
}
