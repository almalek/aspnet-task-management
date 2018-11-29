using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Codex.Models;
using Microsoft.EntityFrameworkCore;

namespace Codex.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CodexContext _context;

        public DashboardController(CodexContext context)
        {
             _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalTasks = _context.Tasks.Include(t => t.Employee).Count();
            ViewBag.TotalEmployees = _context.Employees.Count();

            ViewBag.openTasksCount = _context.Tasks.Where(o => o.Status.Contains("Open")).Count();
            ViewBag.pendingTasksCount = _context.Tasks.Where(o => o.Status.Contains("Pending")).Count();
            ViewBag.closedTasksCount = _context.Tasks.Where(o => o.Status.Contains("Closed")).Count();

            ViewBag.highTasksCount = _context.Tasks.Where(o => o.Priority.Contains("High")).Count();
            ViewBag.mediumTasksCount = _context.Tasks.Where(o => o.Priority.Contains("Medium")).Count();
            ViewBag.lowTasksCount = _context.Tasks.Where(o => o.Priority.Contains("Low")).Count();

            var codexContext = _context.Tasks.Include(t => t.Employee).FromSql("SELECT * FROM Tasks WHERE Status='Open' OR status='Pending'");
            return View(await codexContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
    }
}
