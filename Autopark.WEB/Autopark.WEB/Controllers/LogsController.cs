using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autopark.DAL.EF;
using Autopark.WEB.Entities;

namespace Autopark.WEB.Controllers
{
    public class LogsController : Controller
    {
        private readonly RdbmsdbContext _context;

        public LogsController(RdbmsdbContext context)
        {
            _context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var rdbmsdbContext = _context.Logs.Include(l => l.CustomerUser);
            return View(await rdbmsdbContext.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.CustomerUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

    }
}
